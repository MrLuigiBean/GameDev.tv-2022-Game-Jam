using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrailing : MonoBehaviour
{
	public Transform ghost_trfm, leftBound_trfm, rightBound_trfm, topBound_trfm, bottomBound_trfm;
	public float smoothingSpeed;
	// Start is called before the first frame update
	void Start()
	{
		//this.transform.position = ghost_trfm.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 leftBoundPos = this.GetComponent<Camera>().WorldToViewportPoint(leftBound_trfm.position);
		Vector3 rightBoundPos = this.GetComponent<Camera>().WorldToViewportPoint(rightBound_trfm.position);
		Vector3 topBoundPos = this.GetComponent<Camera>().WorldToViewportPoint(topBound_trfm.position);
		Vector3 bottomBoundPos = this.GetComponent<Camera>().WorldToViewportPoint(bottomBound_trfm.position);
		Vector3 targetPos = this.GetComponent<Camera>().WorldToViewportPoint(ghost_trfm.position);
		Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, ghost_trfm.position, smoothingSpeed);

		//Bounds checking
		//X
		if ((leftBoundPos.x <= 0 || targetPos.x >= 0.55) && (rightBoundPos.x >= 1 || targetPos.x <= 0.45))
		{
			this.transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
		}
		//Y - I CANT SEEM TO DO Y
		//if ((bottomBoundPos.y <= 0 || targetPos.y >= 0.55) && (topBoundPos.y >= 1 || targetPos.y <= 0.45))
		//{
		//	this.transform.position = new Vector3(0, smoothedPosition.y, -10);
		//}
	}
}
