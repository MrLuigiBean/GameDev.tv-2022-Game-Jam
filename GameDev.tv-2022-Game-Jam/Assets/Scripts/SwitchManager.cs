using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
	// Declare References
	[Header("References")]
	[SerializeField] private GameObject connectedDevice;


	public bool isPressed;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isPressed = true;
			// Activate Device
			if (connectedDevice.GetComponent<GateDeviceBehaviour>())
				connectedDevice.GetComponent<GateDeviceBehaviour>().ToggleGate();
		}
	}
}
