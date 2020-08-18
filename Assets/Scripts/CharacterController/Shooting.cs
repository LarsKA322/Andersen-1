using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public float hitForce = 100f;
    public float fireRate = .25f;

    //this will mark the position at which our firebolt will begin, aka the point where our soon-to-be hand animations will point/end
    public Transform handsEnd;
    public GameObject fireball;
    private float nextFire;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Debug.Log("Pew");
            nextFire = Time.time + fireRate;
            GameObject thisproj = Instantiate(fireball, handsEnd.transform.position, Quaternion.identity) as GameObject;
            Vector3 localForward = thisproj.transform.worldToLocalMatrix.MultiplyVector(transform.forward);
            thisproj.GetComponent<Rigidbody>().AddForce(localForward * hitForce);
        }
        
    }
}
