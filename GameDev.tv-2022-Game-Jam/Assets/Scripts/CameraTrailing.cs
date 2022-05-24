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
	}

	// Update is called once per frame
	void LateUpdate()
	{
		float aspectRatio = this.GetComponent<Camera>().aspect;
		float orthographicSize = this.GetComponent<Camera>().orthographicSize;
		float leftBoundOffset = leftBound_trfm.position.x + (orthographicSize * aspectRatio);
		float rightBoundOffset = rightBound_trfm.position.x - (orthographicSize * aspectRatio);
		float topBoundOffset = topBound_trfm.position.y - orthographicSize;
		float bottomBoundOffset = bottomBound_trfm.position.y + orthographicSize;
		Vector3 boundPosition = new Vector3(Mathf.Clamp(ghost_trfm.localPosition.x, leftBoundOffset, rightBoundOffset),
											Mathf.Clamp(ghost_trfm.localPosition.y, bottomBoundOffset, topBoundOffset),
											-10);

		Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, boundPosition, smoothingSpeed);
		this.transform.position = smoothedPosition;
	}
}
