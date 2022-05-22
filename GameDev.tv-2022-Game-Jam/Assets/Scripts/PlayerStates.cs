using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Declare variables
    [Header("List of Potential Collision")]
    [SerializeField] List<string> List_Human_Lethal = new List<string> { "Lethal Terrain" };

    [SerializeField] public enum PlayerExistance { Human, Ghost };
    [Header("Player's Game State")]
    [SerializeField] public PlayerExistance CurrentPlayerState = PlayerExistance.Human;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (List_Human_Lethal.Contains(collision.tag))
            {
                CurrentPlayerState = PlayerExistance.Ghost;
                Debug.Log("OOOO");
            }
        }
    }
}
