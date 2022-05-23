using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
	// Declare References
	[Header("References")]
	[SerializeField] private GameObject connectedDevice;


	public bool isPressed;

	// Start is called before the first frame update
	//void Start()
	//{

	//}

	// Update is called once per frame
	// void Update()
	// {
	// 	;
	// }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isPressed = true;
			// Activate Device
			if (connectedDevice.GetComponent<GateDeviceBehaviour>())
				connectedDevice.GetComponent<GateDeviceBehaviour>().ToggleGate();
		}
	}
}
