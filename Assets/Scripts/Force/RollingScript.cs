using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class RollingScript : MonoBehaviour
{
    private Rigidbody _body;
    private bool isGrounded;
    private Transform _groundCheck;
    public float groundDistance;
    public LayerMask rampMask;
    public float torqueSpeed;
    private float afterHeight;
    private float nowHeight;
    private bool _dir;

    private void Start() {
        afterHeight = this.transform.position.y;
        _body = this.GetComponent<Rigidbody>();
        _groundCheck = transform.GetChild(0);
    }
    private void Update() {

        isGrounded = Physics.CheckSphere(_groundCheck.position, groundDistance, rampMask);
    }
    void FixedUpdate()
    {
        //Vector3 relativePos = target.position - transform.position;
        nowHeight = this.gameObject.transform.position.y;
        if(nowHeight < afterHeight && isGrounded == true)
        {
            this._body.AddForce(_body.velocity * Time.deltaTime * torqueSpeed);
        }else{
            this._body.angularVelocity = Vector3.zero;
        }

        afterHeight = nowHeight;   
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, groundDistance);
    }
}
