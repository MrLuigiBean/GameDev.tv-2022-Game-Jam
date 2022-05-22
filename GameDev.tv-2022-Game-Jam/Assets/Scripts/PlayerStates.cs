using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Declare References
    [Header("References")]
    [SerializeField] public GameObject TheOverseer;

    // Declare variables
    [Header("List of Potential Collision")]
    [SerializeField] public List<string> List_Human_Lethal = new List<string> { "Lethal Terrain" };
    [SerializeField] public List<string> List_Win = new List<string> { "Finish" };

    [SerializeField] public enum PlayerExistance { Human, Ghost };
    [Header("Player's Game State")]
    [SerializeField] public PlayerExistance CurrentPlayerState = PlayerExistance.Human;

    [Header("Game Object Reference")]
    public GameObject human, ghost;

    // Start is called before the first frame update
    void Start()
    {
        if (TheOverseer == null)
            Debug.Log("[PlayerStates.cs] ERROR! TheOverseer is null! Please reference to the Overseer for functions to work!");
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<BoxCollider2D>().OnColl

        //Temporary to delete -  FOR DEBUGGING
        if (Input.GetKeyDown(KeyCode.X))
        {
            CurrentPlayerState = PlayerExistance.Ghost;
        }

        switch (CurrentPlayerState)
        {
            case PlayerExistance.Human:
                ghost.SetActive(false);
                break;
            case PlayerExistance.Ghost:
                ghost.SetActive(true);
                break;
        }
    }
}
