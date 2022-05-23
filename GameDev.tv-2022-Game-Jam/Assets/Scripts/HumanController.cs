using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
	[SerializeField] public GameObject playerHandler;
	[HideInInspector] public bool jumpable = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//If human form
		if (playerHandler.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Human)
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
		//Jump
		if (collision.gameObject.CompareTag("Platforms"))
		{
			jumpable = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Platforms"))
		{
			jumpable = false;
		}
	}
}
