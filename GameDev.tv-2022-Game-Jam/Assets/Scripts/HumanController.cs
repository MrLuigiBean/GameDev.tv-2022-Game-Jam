using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
	[SerializeField] public GameObject playerHandler;

	private void OnTriggerStay2D(Collider2D collision)
	{
		//If human form
		if (playerHandler.GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Human)
		{
			// Win Game [ONLY in Human Form AND TheOverseer exists]
			if (playerHandler.GetComponent<PlayerStates>().list_Win.Contains(collision.tag) && playerHandler.GetComponent<PlayerStates>().theOverseer != null)
			{
				playerHandler.GetComponent<PlayerStates>().theOverseer.GetComponent<OverseerBehaviour>().CompleteLevel();
				Debug.Log("You WIN!");
			}
			//Kill players
			if (playerHandler.GetComponent<PlayerStates>().list_Human_Lethal.Contains(collision.tag))
			{
				playerHandler.GetComponent<PlayerStates>().ChangeExistence(PlayerStates.PlayerExistence.Ghost);
				Debug.Log("Oooooo.... I'm a Ghost....");
			}

		}
	}
}
