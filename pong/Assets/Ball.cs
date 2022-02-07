using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    public float speedI = 5f;
    private float movementPerSecond = 80f;
    public float baseMovement = 1f;
    private Rigidbody rBody;
    private int resetDirection;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Invoke("RoundStart", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void RoundStart(){
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rBody.velocity = new Vector3(10, 0,0) * movementPerSecond * Time.deltaTime;
        } 
        else {
            rBody.velocity = new Vector3(-10, 0,0) * movementPerSecond * Time.deltaTime;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 reflect = Vector3.Reflect(rBody.velocity, collision.contacts[0].normal);
    
        movementPerSecond += speedI;
        Debug.Log("Current speed is at: " + movementPerSecond);
        rBody.velocity = reflect * movementPerSecond * Time.deltaTime ;
        
    
    }

    void RoundReset()
    {
        movementPerSecond = baseMovement;
        rBody.velocity = new Vector3(resetDirection, 0,0) * movementPerSecond * Time.deltaTime;
      
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        rBody.velocity = Vector3.zero;
        transform.position = Vector3.zero;

        if (other.gameObject.name == "LeftGoal")
        {
            resetDirection = -10;
        }
        else
        {
            resetDirection = 10;
        }
        //other.gameObject.name
        Invoke("RoundReset", 2);
    }
}
