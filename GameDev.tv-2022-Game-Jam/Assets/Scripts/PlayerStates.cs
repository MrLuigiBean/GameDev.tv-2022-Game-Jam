using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Declare References
    [Header("References")]
    [SerializeField] private GameObject TheOverseer;

    // Declare variables
    [Header("List of Potential Collision")]
    [SerializeField] private List<string> List_Human_Lethal = new List<string> { "Lethal Terrain" };
    [SerializeField] private List<string> List_Win = new List<string> { "Finish" };

    [SerializeField] public enum PlayerExistance { Human, Ghost };
    [Header("Player's Game State")]
    [SerializeField] public PlayerExistance CurrentPlayerState = PlayerExistance.Human;

    // Start is called before the first frame update
    void Start()
    {
        if (TheOverseer == null)
            Debug.LogError("[PlayerStates.cs] ERROR! TheOverseer is null! Please reference to the Overseer for functions to work!");
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<BoxCollider2D>().OnColl
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurrentPlayerState == PlayerExistance.Human)
        {
            // Win Game [ONLY in Human Form AND TheOverseer exists]
            if (List_Win.Contains(collision.tag) && TheOverseer != null)
            {
                TheOverseer.GetComponent<OverseerBehaviour>().CompleteLevel();
                Debug.Log("You WIN!");
            }
            // Kill Players
            if (List_Human_Lethal.Contains(collision.tag))
            {
                CurrentPlayerState = PlayerExistance.Ghost;
                Debug.Log("Oooooo.... I'm a Ghost....");
            }
        }
    }
}
