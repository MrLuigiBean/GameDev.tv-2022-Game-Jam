using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
	public bool isPressed;

	// Start is called before the first frame update
	//void Start()
	//{

	//}

	// Update is called once per frame
	void Update()
	{
		;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			isPressed = true;
			Debug.Log("we made it!");
		}
	}
}
