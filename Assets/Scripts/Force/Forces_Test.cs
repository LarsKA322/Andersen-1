using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces_Test : MonoBehaviour
{
    public Vector3 localVelo;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();    
    }
    // Update is called once per frame
    void Update()
    {
        //localVelo = transform.InverseTransformDirection(rigidbody.velocity);
        Debug.Log(rigidbody.velocity);
    }
}
