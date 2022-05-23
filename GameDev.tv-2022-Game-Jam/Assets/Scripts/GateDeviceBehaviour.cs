using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDeviceBehaviour : MonoBehaviour
{
	// Declare References
	[Header("References")]
	[SerializeField] private GameObject deviceEnd;
	[SerializeField] private GameObject redGatePrefab;
	[SerializeField] private GameObject greenGatePrefab;
	[SerializeField] private GameObject playerHandler;

	// Declare variables
	[SerializeField] private enum GateTypes { Red, Green };
	[Header("Gate Variables")]
	[SerializeField] private GameObject gateObject;
	[SerializeField] private GateTypes gateType = GateTypes.Red;
	[SerializeField] private bool activation = false;
	[SerializeField] private Vector3 gateDistance = new Vector3(0, 0, 0);
	[SerializeField] private Vector3 gateScale = new Vector3(0, 0, 0);

	// Start is called before the first frame update
	void Start()
	{
		// Ensure all references are present
		if (deviceEnd == null)
			Debug.LogError("[GateDeviceBehaviour.cs] ERROR! deviceEnd is null!");
		if (redGatePrefab == null)
			Debug.LogError("[GateDeviceBehaviour.cs] ERROR! redGatePrefab is null!");
		if (greenGatePrefab == null)
			Debug.LogError("[GateDeviceBehaviour.cs] ERROR! greenGatePrefab is null!");

		// Get playerHandler manually (Since it is not a prefab)
		playerHandler = GameObject.Find("PlayerHandler");
	}

	// Update is called once per frame
	void Update()
	{
		// Activate Gate
		if (activation && gateObject == null)
		{
			// Update Animation
			GetComponent<Animator>().SetBool("isActivated", true);

			// Calculate Gate Distance
			gateDistance = (deviceEnd.transform.position - transform.position) / 2;
			gateScale = new Vector3(1, 1, 0) + gateDistance * 1.9f;

			// Check Gate Type
			if (gateType == GateTypes.Red)
			{
				gateObject = Instantiate(redGatePrefab, transform.position + gateDistance, transform.rotation, transform);
				gateObject.GetComponent<BoxCollider2D>().isTrigger = playerHandler.GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Human;
			}
			else if (gateType == GateTypes.Green)
			{
				gateObject = Instantiate(greenGatePrefab, transform.position + gateDistance, transform.rotation, transform);
				gateObject.GetComponent<BoxCollider2D>().isTrigger = playerHandler.GetComponent<PlayerStates>().GetPlayerState() != PlayerStates.PlayerExistence.Human;
			}

			gateObject.transform.localScale = gateScale;
			gateObject.transform.localRotation = transform.rotation;
		}
		// Deactivate Gate
		else if (!activation && gateObject != null)
		{
			// Update Animation
			GetComponent<Animator>().SetBool("isActivated", false);

			Destroy(gateObject);
			gateObject = null;
		}
	}

	public void ToggleGate()
	{
		activation = !activation;
	}
}
