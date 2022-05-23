using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
	[SerializeField] public GameObject playerHandler;

	// Start is called before the first frame update
	// void Start()
	// {

	// }

	// Update is called once per frame
	// void Update()
	// {

	// }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//If human form
		if (playerHandler.GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Ghost)
		{
			//Revive player
			if (playerHandler.GetComponent<PlayerStates>().list_Ghost_Revival.Contains(collision.tag))
			{
				playerHandler.GetComponent<PlayerStates>().ChangeExistence(PlayerStates.PlayerExistence.Human);
				Debug.Log("I'm back from the grave to give the living haircuts!");
			}
		}
	}
}
