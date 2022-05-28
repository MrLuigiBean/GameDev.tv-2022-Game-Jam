using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// public SpriteRenderer sr;
	public GameObject humanGO, humanOCB, humanOCL, humanOCR, ghostGO; //GO: Game Object | OC: Offset Collider Game Object
	private Rigidbody2D humanRB, ghostRB;

	[SerializeField] private float hsp; // Horizontal Speed
	[SerializeField] private float vsp; // Vertical Speed
	[SerializeField] private float jmpForce;//Jump Force

	bool PlayerIsHuman()
	{
		return GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Human;
	}

	bool PlayerIsGhost()
	{
		return GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Ghost;
	}

	private void Start()
	{
		humanRB = humanGO.GetComponent<Rigidbody2D>();
		ghostRB = ghostGO.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		bool moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
		bool moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
		bool moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
		bool moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);

		// Get Directions
		int horizontalDir = moveLeft ? -1 : 0;
		horizontalDir += moveRight ? 1 : 0;
		int verticalDir = moveDown && PlayerIsGhost() ? -1 : 0;
		verticalDir += moveUp ? 1 : 0;

		// Calculate Movement based on Directions
		if (PlayerIsHuman())
		{
			// Check if can jump
			if (humanOCB.GetComponent<ColliderOffset>().isTriggered && moveUp)
				humanRB.velocity = new Vector2(humanRB.velocity.x, jmpForce);
			// Set velocity based on direction
			humanRB.velocity = new Vector2(horizontalDir * hsp, humanRB.velocity.y);
			// Check if colliding with a wall horizontally
			if (humanOCL.GetComponent<ColliderOffset>().isTriggered && horizontalDir == -1)
				humanRB.velocity = new Vector2(0, humanRB.velocity.y);
			if (humanOCR.GetComponent<ColliderOffset>().isTriggered && horizontalDir == 1)
				humanRB.velocity = new Vector2(0, humanRB.velocity.y);

			// Move ghost to human
			ghostGO.transform.localPosition = humanGO.transform.localPosition;
		}
		if (PlayerIsGhost())
		{
			// Set velocity based on direction
			ghostRB.velocity = new Vector2(horizontalDir * hsp, verticalDir * vsp);
		}
	}
}
