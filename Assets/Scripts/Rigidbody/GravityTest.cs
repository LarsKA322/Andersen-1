using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityTest : MonoBehaviour
{
    // Start is called before the first frame update
     public bool useGravity = true;
     private Rigidbody rigidbody;
 
     void Awake() {
         rigidbody = GetComponent<Rigidbody>();
     }
     
     void FixedUpdate() {
         rigidbody.useGravity = false;

         if (useGravity){
             rigidbody.AddForce(Physics.gravity * (rigidbody.mass * rigidbody.mass));
         }
     }
}
