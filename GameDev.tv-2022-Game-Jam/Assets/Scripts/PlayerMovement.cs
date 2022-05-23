using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// public SpriteRenderer sr;
	public GameObject humanGO, ghostGO;
	private Rigidbody2D humanRB, ghostRB;
	private bool isJumpable;
	[SerializeField] Vector2 movement = Vector2.zero;
	[SerializeField] private float movementAcceleration = 0.001f ;
	[SerializeField] private float movementSpeedCap = 1.0f ;
	[SerializeField] public float movementSpeed = 2.0f;

	[SerializeField] private float humanJumpY = 0.0f;
	[SerializeField] private bool humanHasJump = false;
	[SerializeField] private float humanJumpCap = 1.0f;

	void Awake()
	{
		//this.GetComponent<PlayerStates>().currentPlayerState;
	}

	private void Start()
	{
		humanRB = humanGO.GetComponent<Rigidbody2D>();
		ghostRB = ghostGO.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		isJumpable = humanGO.GetComponent<HumanController>().jumpable;
		//movement = Vector2.zero;
		
		if (this.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Ghost)
		{
			if (movement.y < movementSpeedCap && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
			{
				movement += new Vector2(0, movementAcceleration);
				//movement += Vector2.up;
			}
			if (movement.y > -movementSpeedCap && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
			{
				movement += new Vector2(0, -movementAcceleration);
				//movement += Vector2.down;
			}
		}
		else
		{
			if (!humanHasJump && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && humanGO.GetComponent<Rigidbody2D>().velocity.y == 0)
			{
				//movement += Vector2.up;
				humanHasJump = true;
				//movement += new Vector2(0, movementAcceleration);
				Debug.Log("jump");
				//humanRB.MovePosition
				//humanGO.transform.Translate(new Vector3(0, 5));

			}
		}

		if (movement.x > -movementSpeedCap && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
		{
			//movement += Vector2.left;
			movement += new Vector2(-movementAcceleration, 0);
		}
		if (movement.x < movementSpeedCap && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
		{
			//movement += Vector2.right;
			//sr.flipX = !sr.flipX;
			movement += new Vector2(movementAcceleration, 0);
		}

		// Account Lerp Jump
		if (humanHasJump)
        {
			if (humanJumpY <= humanJumpCap)
			{
				humanJumpY += movementSpeed * Time.deltaTime;
				movement += new Vector2(0, humanJumpY);
			}
            else
            {
				humanHasJump = false;
				humanJumpY = 0;
			}
		}

		if (movement != Vector2.zero)
		{
			//movement.Normalize();
			//movement = movementSpeed * Time.deltaTime * movement;
			movement = Vector2.Lerp(movement, Vector2.zero, movementSpeed * Time.deltaTime);
			if (this.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Human)
			{
				humanRB.MovePosition(humanRB.position + movement);
			}
			if (this.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Ghost)
			{
				ghostRB.MovePosition(ghostRB.position + movement);
			}
		}

		if (this.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Human)
		{
			ghostGO.transform.position = humanGO.transform.position;
		}
	}
}
