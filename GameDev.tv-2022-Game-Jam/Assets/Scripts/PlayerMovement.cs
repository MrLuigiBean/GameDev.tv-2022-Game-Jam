using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;
	// public SpriteRenderer sr;
	public GameObject humanGO, ghostGO;
	private Rigidbody2D humanRB, ghostRB;
	private bool isJumpable;

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
		Vector2 movement = Vector2.zero;
		if(this.GetComponent<PlayerStates>().currentPlayerState == PlayerStates.PlayerExistence.Ghost)
        {
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				movement += Vector2.up;
			}
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				movement += Vector2.down;
			}
		}
		else
        {
			if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isJumpable)
            {
				//movement += new Vector2(0,200);
				Debug.Log("jump");
				//humanRB.MovePosition
				//humanGO.transform.Translate(new Vector3(0, 5));

			}
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
