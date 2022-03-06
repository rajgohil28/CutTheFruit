
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Rigidbody rb;
    public float ForceMagnitude;
    public float TorqueMagnitude;
    public bool isUpperPart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(1, 0, 0) * ForceMagnitude);
        if (isUpperPart)
            transform.Rotate(new Vector3(0f, 0.1f, 0f));
        else
            transform.Rotate(new Vector3(0f, -0.1f, 0f));
        
        rb.AddTorque(new Vector3(0, 0, 1) * TorqueMagnitude);
    }
}
