using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;

	// Start is called before the first frame update
	//void Start()
	//{

	//}

	// Update is called once per frame
	void Update()
	{
		Vector2 movement = Vector2.zero;
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			movement += Vector2.up;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			movement += Vector2.down;
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			movement += Vector2.left;
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			movement += Vector2.right;
		}

		if (movement != Vector2.zero)
		{
			movement.Normalize();
			movement = movementSpeed * Time.deltaTime * movement;
			transform.Translate(movement, Space.World);
		}
	}
}
