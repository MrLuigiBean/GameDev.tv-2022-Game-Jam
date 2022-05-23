using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// public SpriteRenderer sr;
	public GameObject humanGO, humanOC, ghostGO; //GO: Game Object | OC: Offset Collider Game Object
	private Rigidbody2D humanRB, ghostRB;

	[SerializeField] private float hsp;	// Horizontal Speed
	[SerializeField] private float vsp;	// Vertical Speed
	[SerializeField] private float jmpForce;//Jump Force

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
		bool moveLeft = (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A));
		bool moveRight = (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D));
		bool moveDown = (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S));
		bool moveUp = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space));

		// Get Directions
		int horizontalDir = (moveLeft ? -1 : 0);
		horizontalDir += (moveRight ? 1 : horizontalDir);
		int verticalDir = (moveDown && GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Ghost ? -1 : 0);
		verticalDir += (moveUp ? 1 : 0);

		// Calculate Movement based on Directions
		if (this.GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Human)
		{
			// Check if can jump
			if (humanOC.GetComponent<ColliderOffset>().isTriggered && moveUp)
				humanRB.AddForce(new Vector2(0, jmpForce));
			float movementHumanx = humanGO.transform.localPosition.x + horizontalDir * hsp * Time.deltaTime;
			float movementHumany = humanGO.transform.localPosition.y;
			humanGO.transform.localPosition = new Vector2(movementHumanx, movementHumany);
			ghostGO.transform.localPosition = humanGO.transform.localPosition;
		}
		if (this.GetComponent<PlayerStates>().GetPlayerState() == PlayerStates.PlayerExistence.Ghost)
		{
			float movementGhostx = ghostGO.transform.localPosition.x + horizontalDir * hsp * Time.deltaTime;
			float movementGhosty = ghostGO.transform.localPosition.y + verticalDir * vsp * Time.deltaTime;
			ghostGO.transform.localPosition = new Vector2(movementGhostx, movementGhosty);
		}
	}
}
