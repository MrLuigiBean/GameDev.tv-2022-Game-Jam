using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;
	// public SpriteRenderer sr;

	// Start is called before the first frame update
	//void Start()
	//{

	//}

	// Update is called once per frame
	void Update()
	{
		Vector2 movement = Vector2.zero;
		if (Input.GetAxis("Vertical") > 0)
		{
			movement += Vector2.up;
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			movement += Vector2.down;
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			movement += Vector2.left;
		}
		if (Input.GetAxis("Horizontal") > 0)
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
