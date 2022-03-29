using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVR : MonoBehaviour
{
    public GameObject AfterCutPrefab;
    public GameObject CutParticleEffect;
    public float startForce = 6.5f;
    public float FruitLifeSpan = 5f;

    bool IsSlicedByBlade = false;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * startForce, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * startForce, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade" && !IsSlicedByBlade)                        //Detecting Blade Collision
        {
            IsSlicedByBlade = true;
            Vector3 direction = other.transform.position - transform.position;          //Determining Cut Direction

            Quaternion rotation = Quaternion.LookRotation(direction);                       //Feeding Cut direction Rotation Accordingly
            Debug.Log("Cut fruit Position" + transform.position);

            GameObject CutPrefab = Instantiate(AfterCutPrefab, transform.position, rotation);                      //Instiantiating Cut Fruit
            GameObject Effect = Instantiate(CutParticleEffect, transform.position, Quaternion.Euler(180f, 0f, 0f));
            Destroy(gameObject);                                                            //Destroying Fruit
            Destroy(Effect, 4f);
            Destroy(CutPrefab, 3f);
            FindObjectOfType<VRGameManager>().IncreaseScore();                                // Add Score
        }
    }
    public void Update()
    {
        Destroy(gameObject, FruitLifeSpan);
    }
}
