using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverseerBehaviour : MonoBehaviour
{
    [Header("Game State")]
    [SerializeField] private int Level = 0;
    [SerializeField] private bool Completion = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to run after completing a level
    public void CompleteLevel()
    {
        Completion = true;

        // To Add [Events after completing level (Ex. Victory UI, etc)]
    }
}