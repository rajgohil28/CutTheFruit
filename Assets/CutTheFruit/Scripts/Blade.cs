using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject BladeTrailPrefab;          //TrailRennderer for Blade
    public float minCuttingVelocity= 0.0005f;           //If Speed isnt greater then minCuttingVelocity then fruit will not cut
    public AudioSource bladeSound;                      //AudioSource For BladeSound
    private GameObject ComboHolder;

    bool isCutting = false;                     //If Blade is cutting Fruit 
    int FruitCutInOneSlice;                    //FruitCutInOneSlice;


    GameObject currentBladeTrail;               // Current Blade Trail in Game
    Vector2 previousPosition;                   //Previous Touch Position
    Rigidbody2D rb;                             //RigidBody For Blade (Even Kinematic Unity will consider it as a physics Object) 
    CircleCollider2D bladeCollider;             //Collider For Fruit Cut Interaction 
    Camera MainCam;                             //Main Camera
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bladeCollider = GetComponent<CircleCollider2D>();
        MainCam = Camera.main;
        ComboHolder = GameObject.FindGameObjectWithTag("ComboHolder");
    }
    void Update()
    {

        StartCutting();

        /*if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }*/
        if (isCutting)
        {
            UpdateBladeCutting();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void UpdateBladeCutting()
    {
        
        /*float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;       //Registering Velocity V = (pf-pi) * 1/T


        if (velocity > minCuttingVelocity)                                                  // Checking if velocity is acceptable
            bladeCollider.enabled = true;
        else
            bladeCollider.enabled = false;

        previousPosition = newPosition;        */                                   // Updating Previous Position



    }

    private void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(BladeTrailPrefab, transform);                       // Instiantiating Blade Trail
        bladeCollider.enabled = true;
        //bladeSound.Play();
    }

    /*private void StopCutting()
    {
        Debug.Log("Combo:" + FruitCutInOneSlice);
        isCutting = false;
        bladeCollider.enabled = false;
        currentBladeTrail.transform.SetParent(null);                                        //Deparanting Blade Trail Object
        Destroy(currentBladeTrail, 2f);                                                     // Destroying Blade Trail
        bladeSound.Pause();
        FruitCutInOneSlice = 0;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            if (isCutting)
            {
                FruitCutInOneSlice++;
            }
            if (FruitCutInOneSlice == 3)
            {
                FindObjectOfType<GameManagerFruitCut>().ThreeFruitCombo();
            }
        }
    }
}
