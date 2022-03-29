using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableVR : MonoBehaviour
{
    public float startForce = 6.5f;

    Rigidbody rb;
    AudioSource _vegetableAudio;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * startForce, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Blade")                        //Detecting Blade Collision
        {
            VRGameManager vrmanager = FindObjectOfType<VRGameManager>();
            vrmanager.LifeDeductAudio.Play();
            vrmanager.GameOver();
        }
    }
}
