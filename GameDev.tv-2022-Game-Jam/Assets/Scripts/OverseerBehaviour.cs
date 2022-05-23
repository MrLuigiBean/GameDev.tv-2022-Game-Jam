using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverseerBehaviour : MonoBehaviour
{
	[Header("Game State")]
	[SerializeField] private int level = 0;
	[SerializeField] private bool completion = false;

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
		completion = true;

		// To Add [Events after completing level (Ex. Victory UI, etc)]
	}
}
