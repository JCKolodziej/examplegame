using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    public float PlayerSpeed = 1.0f;
    public float PlayerJump = 1.0f;
    public UnityEvent OnPointScored;
    public UnityEvent timesUp;



    private Rigidbody _rigidbody;
    private bool _grounded;

    
    private void Start()
    {
        _grounded = false;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var force = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            // forward
            force += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // backward
            force += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // left
            force += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // right
            force += Vector3.right;
        }
     

        _rigidbody.AddForce(force*PlayerSpeed*Time.deltaTime*100.0f);
        if (_grounded)
        {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                _rigidbody.AddForce(Vector3.up*PlayerJump*Time.deltaTime*100.0f, ForceMode.Impulse);

                _grounded = false;
             }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Jumpable")
        {
            _grounded = true;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Point")
        {
            // point

            col.GetComponent<Point>().OnPlayerCollision();
        }
    }




    
}
