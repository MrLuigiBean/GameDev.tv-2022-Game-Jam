using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverseerBehaviour : MonoBehaviour
{
	[Header("Game State")]
	[SerializeField] private int level = 0;
	[SerializeField] private bool completion = false;

	// Start is called before the first frame update
	// void Start()
	// {

	// }

	// Update is called once per frame
	void Update()
	{
		// TEMP: Load next scene/level
		if (Input.GetKey(KeyCode.Return))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if (Input.GetKey(KeyCode.Backslash))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		// TEMP: Retart current scene/level
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	// Function to run after completing a level
	public void CompleteLevel()
	{
		completion = true;

		// To Add [Events after completing level (Ex. Victory UI, etc)]
	}
}
