using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Declare References
    [Header("References")]
    [SerializeField] public GameObject theOverseer;

    // Declare variables
    [Header("List of Potential Collision")]
    [SerializeField] public List<string> list_Human_Lethal = new List<string> { "Lethal Terrain" };
    [SerializeField] public List<string> list_Human_Obstacles = new List<string> { "Red Gate" };
    [SerializeField] public List<string> list_Win = new List<string> { "Finish" };

    [SerializeField] public enum PlayerExistence { Human, Ghost };
    [Header("Player's Game State")]
    [SerializeField] public PlayerExistence currentPlayerState;

    [Header("Game Object Reference")]
    public GameObject human, ghost;

    // Start is called before the first frame update
    void Start()
    {
        if (theOverseer == null)
            Debug.LogError("[PlayerStates.cs] ERROR! TheOverseer is null! Please reference to the Overseer for functions to work!");

        // Set it to human
        ChangeExistence(PlayerExistence.Human);
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<BoxCollider2D>().OnColl

        // Ensure ghost and human wont collide with each other
        Physics2D.IgnoreCollision(GetComponent<PlayerMovement>().ghostGO.GetComponent<BoxCollider2D>(), GetComponent<PlayerMovement>().humanGO.GetComponent<BoxCollider2D>());

        //Temporary to delete -  FOR DEBUGGING
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentPlayerState == PlayerExistence.Human)
                ChangeExistence(PlayerExistence.Ghost);
            else
                ChangeExistence(PlayerExistence.Human);
        }

        switch (currentPlayerState)
        {
            case PlayerExistence.Human:
                ghost.SetActive(false);
                break;
            case PlayerExistence.Ghost:
                ghost.SetActive(true);
                break;
        }
    }

    // USE THIS TO CHANGE STATE! [To update all objects affected when player change existence]
    public void ChangeExistence(PlayerExistence existence)
    {
        currentPlayerState = existence;

        // Change Passable for Human
        // Red Gate
        GameObject[] allRedGates = GameObject.FindGameObjectsWithTag("Red Gate");
        foreach (GameObject GO in allRedGates)
        {
            // Make all red gates passable for human, not ghost
            if (GO.GetComponent<BoxCollider2D>())
                GO.GetComponent<BoxCollider2D>().isTrigger = (existence == PlayerExistence.Human);
        }

        // Change Passable for Ghost
        // Platforms
        GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platforms");
        foreach (GameObject GO in allPlatforms)
        {
            // Make all green gates passable for ghost, not human
            if (GO.GetComponent<BoxCollider2D>())
                GO.GetComponent<BoxCollider2D>().isTrigger = (existence == PlayerExistence.Ghost);
        }
        // Green Gate
        GameObject[] allGreenGates = GameObject.FindGameObjectsWithTag("Green Gate");
        foreach (GameObject GO in allGreenGates)
        {
            // Make all green gates passable for ghost, not human
            if (GO.GetComponent<BoxCollider2D>())
                GO.GetComponent<BoxCollider2D>().isTrigger = (existence == PlayerExistence.Ghost);
        }
    }
}
