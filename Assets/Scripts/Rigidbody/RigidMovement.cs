using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    private Rigidbody _body;
    public float speed = 12f;
    public float jumpHeight = 3f;
    Vector3 _inputs = Vector3.zero;
    

    //GroundChecker, Velocity resetting
    private Transform _groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float afterHeight;

    bool isGrounded;

    public void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundCheck = transform.GetChild(0);
    }

    public void Update()
    {
        //This is like a child-friendly raycasting system. 
        //we will probably need to add raycasting system for checking what kind of element is hit, but for now this will do. 
        isGrounded = Physics.CheckSphere(_groundCheck.position, groundDistance, groundMask);

        _inputs = Vector3.zero;
        //_inputs.x = Input.GetAxis("Horizontal");
        //_inputs.z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // _inputs *= -1;
        _inputs = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            afterHeight = 0f;
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }


    //fixed update is called before every "physics update", meaning physics updates and classic updates are not synched
    void FixedUpdate()
    {
        
        _body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
        
        //checker y-value for hvornår man falder og dermed aktivere en højere velocity. 
        if(isGrounded == false){
           //float nowHeight = gameObject.transform.position.y;
           // if(nowHeight < afterHeight){
           //     _body.AddForce(Physics.gravity * (_body.mass * _body.mass));
           // }
           // afterHeight = nowHeight; 
        }
        
    }

}
