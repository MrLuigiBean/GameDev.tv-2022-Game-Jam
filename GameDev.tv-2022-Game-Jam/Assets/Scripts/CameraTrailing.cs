using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrailing : MonoBehaviour
{
	public Transform ghost_trfm, leftBound_trfm, rightBound_trfm;
	public float smoothingSpeed;
	public Vector3 offset;
	// Start is called before the first frame update
	void Start()
	{
		//this.transform.position = ghost_trfm.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 leftPos = this.GetComponent<Camera>().WorldToViewportPoint(leftBound_trfm.position);
		Vector3 targetPos = this.GetComponent<Camera>().WorldToViewportPoint(ghost_trfm.position);
		Vector3 targetPosition = ghost_trfm.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, targetPosition, smoothingSpeed);
		//this.transform.position = smoothedPosition;
		
		//Bounds checking
		//Left bounds out of camera frame
		if (leftPos.x <= 0 || targetPos.x >= 0.65)
		{
			this.transform.position = new Vector3(smoothedPosition.x, 0, smoothedPosition.z);
		}

	}
}
