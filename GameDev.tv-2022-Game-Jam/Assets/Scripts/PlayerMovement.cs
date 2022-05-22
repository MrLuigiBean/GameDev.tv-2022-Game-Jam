using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;
	// public SpriteRenderer sr;
	[SerializeField]
	public GameObject GO_human, GO_ghost;

	void Awake()
	{
		//this.GetComponent<PlayerStates>().CurrentPlayerState;
	}
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
			//sr.flipX = !sr.flipX;

		}

		if (movement != Vector2.zero)
		{
			movement.Normalize();
			movement = movementSpeed * Time.deltaTime * movement;
			if (this.GetComponent<PlayerStates>().CurrentPlayerState == PlayerStates.PlayerExistance.Human)
			{
				GO_human.transform.Translate(movement, Space.World);
			}
			if (this.GetComponent<PlayerStates>().CurrentPlayerState == PlayerStates.PlayerExistance.Ghost)
			{
				GO_ghost.transform.Translate(movement, Space.World);
			}
		}

		if (this.GetComponent<PlayerStates>().CurrentPlayerState == PlayerStates.PlayerExistance.Human)
		{
			GO_ghost.transform.position = GO_human.transform.position;
		}
	}
}
