using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Mover : MonoBehaviour
{
    public float movementPerSecond = 10f;
    public string paddleName;

    private Rigidbody _rbody;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float movementAxis;
        if (paddleName == "leftPaddle")
        {
             movementAxis = Input.GetAxis("Vertical");
        }
        else
        {
            movementAxis = Input.GetAxis("Vertical2");
        }

        
        
        
        Vector3 force = Vector3.up * movementAxis * movementPerSecond * Time.deltaTime;

        _rbody.AddForce(force, ForceMode.VelocityChange);
        


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        // BoxCollider bbox = GetComponent<BoxCollider>();
        // float xCenter = bbox.bounds.center.x;
        //
        // Debug.Log("Center at " + xCenter + "collided object at " + collision.transform.position.x);

        // Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;
        
        // Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.red);
        
        // Debug.Break();
    }

 
}
