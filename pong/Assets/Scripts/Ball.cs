using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Ball : MonoBehaviour
{

    public float speedI = 1f;
    public float movementPerSecond = 1f;
    public float baseMovement = 1f;
    private Rigidbody _rBody;
    private float _resetDirection;
    public AudioSource source;
    private Vector3 _currentDirection;
    public AudioClip paddleHit;
    // private float pRangeHigh;
    // private float pRangeLow;
    private float intensity = 0f;
    public AudioSource aSource;
    public AudioClip goalIsMade;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        aSource = GetComponent<AudioSource>();
        _rBody = GetComponent<Rigidbody>();
        Invoke("RoundStart", 2);
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        _rBody.velocity = _currentDirection * movementPerSecond * Time.deltaTime;
    }
    void RoundStart(){
        float rand = Random.Range(0, 2);
        
        if (rand < 1)
        {
            _currentDirection = new Vector3(baseMovement, 0,0);
            
        } 
        else {
            _currentDirection = new Vector3(-baseMovement, 0,0);
            
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            intensity += .1f;
            source.PlayOneShot(paddleHit,intensity);
            movementPerSecond += speedI;
   
           
            _currentDirection = new Vector3(-_currentDirection.x, _currentDirection.y+20 , 0);
            _currentDirection = _currentDirection.normalized * movementPerSecond;
        }
        else 
        {

            //_currentDirection = _currentDirection * movementPerSecond * Time.deltaTime;
            _currentDirection = new Vector3(_currentDirection.x, -_currentDirection.y , 0);
            
            
            Debug.Log("Current speed is at: " + movementPerSecond + " /  " + _rBody.velocity + " / " + Time.deltaTime);
        }


    }



    void RoundReset()
    {
        
        
        _currentDirection = new Vector3(_resetDirection, 0,0);
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.name == "p1")
        {
            Debug.Log("ZOOOOM");
            movementPerSecond += 20;
        }
        
        if (other.gameObject.name == "p2")
        {
            Debug.Log("REVERSE!");
            _currentDirection = new Vector3(-_currentDirection.x, -_currentDirection.y);
        }
        if (other.gameObject.name == "LeftGoal" || other.gameObject.name == "RightGoal")
        {

            movementPerSecond = baseMovement;
            _currentDirection = Vector3.zero;
            transform.position = Vector3.zero;
            aSource.PlayOneShot(goalIsMade, .3F);
            if (other.gameObject.name == "LeftGoal")
            {
                _resetDirection = -baseMovement;
            }
            else
            {
                _resetDirection = baseMovement;
            }
            //other.gameObject.name

            Invoke("RoundReset", 2);
        }
    }
}
