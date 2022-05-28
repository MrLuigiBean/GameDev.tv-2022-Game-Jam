using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOffset : MonoBehaviour
{
	// This script exists because we cant have two box collider2d in one object and it does not allow us to reference OnTriggerEnter until explicitly declared
	// This script also exists because there is no such thing as Sweeptest for Unity2D Engine

	public bool isTriggered = false;
	public List<string> list_Collision_Type;

	// Start is called before the first frame update
	// void Start()
	// {

	// }

	// Update is called once per frame
	// void Update()
	// {

	// }
	private void OnTriggerStay2D(Collider2D collision)
	{
		if ((list_Collision_Type.Count > 0) && list_Collision_Type.Contains(collision.tag))
		{
			isTriggered = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if ((list_Collision_Type.Count > 0) && list_Collision_Type.Contains(collision.tag))
		{
			isTriggered = false;
		}
	}
}
