using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDeviceBehaviour : MonoBehaviour
{
    // Declare References
    [Header("References")]
    [SerializeField] private GameObject DeviceEnd;
    [SerializeField] private GameObject RedGatePrefab;
    [SerializeField] private GameObject GreenGatePrefab;

    // Declare variables
    [SerializeField] private enum GateTypes { Red, Green };
    [Header("Gate Variables")]
    [SerializeField] private GameObject GateObject;
    [SerializeField] private GateTypes GateType = GateTypes.Red;
    [SerializeField] private bool Activation = false;
    [SerializeField] private Vector3 GateDistance = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 GateScale = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Ensure all references are present
        if (DeviceEnd == null)
            Debug.LogError("[GateDeviceBehaviour.cs] ERROR! DeviceEnd is null!");
        if (RedGatePrefab == null)
            Debug.LogError("[GateDeviceBehaviour.cs] ERROR! RedGatePrefab is null!");
        if (GreenGatePrefab == null)
            Debug.LogError("[GateDeviceBehaviour.cs] ERROR! GreenGatePrefab is null!");
    }

    // Update is called once per frame
    void Update()
    {
        // Activate Gate
        if (Activation && GateObject == null)
        {
            // Calculate Gate Distance
            GateDistance = (DeviceEnd.transform.position - transform.position) / 2;
            GateScale = new Vector3(1, 1, 0) + GateDistance * 1.9f;
            GameObject Gate = RedGatePrefab;

            // Check Gate Type
            if (GateType == GateTypes.Red)
                Gate = RedGatePrefab;
            else if (GateType == GateTypes.Green)
                Gate = GreenGatePrefab;

            GateObject = Instantiate(Gate, transform.position + GateDistance, transform.rotation, transform);
            GateObject.transform.localScale = GateScale;
            GateObject.transform.localRotation = transform.rotation;
        }
        // Deactivate Gate
        else if (!Activation && GateObject != null)
        {
            Destroy(GateObject);
            GateObject = null;
        }
    }

    public void ToggleGate()
    {
        Activation = !Activation;
    }
}
