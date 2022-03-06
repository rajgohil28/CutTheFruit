using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject AfterCutPrefab;
    public GameObject CutParticleEffect;
    public GameObject CutFruitSplash;
    public float startForce = 18f;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blade")                        //Detecting Blade Collision
        {
            Vector3 direction = collision.transform.position - transform.position;          //Determining Cut Direction

            Quaternion rotation = Quaternion.LookRotation(direction);                       //Feeding Cut direction Rotation Accordingly
            GameObject CutPrefab = Instantiate(AfterCutPrefab, transform.position, rotation);                      //Instiantiating Cut Fruit
            GameObject Effect = Instantiate(CutParticleEffect, transform.position, Quaternion.Euler(180f,0f,0f));
            GameObject Splash = Instantiate(CutFruitSplash, new Vector3(transform.position.x, transform.position.y,1.5f), transform.rotation);
            Destroy(gameObject);                                                            //Destroying Fruit
            Destroy(Effect, 4f);
            Destroy(CutPrefab, 3f);
            Destroy(Splash, 2f);
            FindObjectOfType<GameManagerFruitCut>().AddScore();   // Add Score
        }
    }
}
