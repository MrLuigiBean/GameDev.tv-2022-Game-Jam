using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField] public GameObject playerHandler;
    [HideInInspector] public bool isJumping;
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
        if (playerHandler.GetComponent<PlayerStates>().CurrentPlayerState == PlayerStates.PlayerExistance.Human)
        {
            // Win Game [ONLY in Human Form AND TheOverseer exists]
            if (playerHandler.GetComponent<PlayerStates>().List_Win.Contains(collision.tag) && playerHandler.GetComponent<PlayerStates>().TheOverseer != null)
            {
                playerHandler.GetComponent<PlayerStates>().TheOverseer.GetComponent<OverseerBehaviour>().CompleteLevel();
                Debug.Log("You WIN!");
            }
            //Kill players
            if (playerHandler.GetComponent<PlayerStates>().List_Human_Lethal.Contains(collision.tag))
            {
                playerHandler.GetComponent<PlayerStates>().CurrentPlayerState = PlayerStates.PlayerExistance.Ghost;
                Debug.Log("Oooooo.... I'm a Ghost....");
            }
        }
        
    }
}
