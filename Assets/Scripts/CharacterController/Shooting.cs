using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Shooting : MonoBehaviour
{
    public float boltRange = 0f;
    public float hitForce = 100f;
    public float fireRate = .25f;

    //this will mark the position at which our firebolt will begin, aka the point where our soon-to-be hand animations will point/end
    public Transform handsEnd;
    private Camera fpsCam;
    private WaitForSeconds boltDuration = new WaitForSeconds(.07f);
    private LineRenderer boltLine;
    private float nextFire;

    private void Start()
    {
        boltLine = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Debug.Log("Pew");
            nextFire = Time.time + fireRate;

            StartCoroutine(BoltEffect());

            //we are passing in a new Vector3 which is set to .5 on the X axis, .5 on the Y axis, and 0 on the Z axis. 
            //This function takes a position relative to the camera's viewport, and converts it to a 3 dimensional point in World space. 
            //By giving this function a Vector3 value, we can use the X and Y values of the Vector3 to determine where on the viewport rectangle our ray should start. 
            //Passing in 0.5 on the X and Y axes specifies a point directly in the center of the view, where we expect the player to aim from.
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

            RaycastHit hit;
            boltLine.SetPosition(0, handsEnd.position);
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, boltRange))
            {
                boltLine.SetPosition(1, hit.point);
            }
            else
            {
                boltLine.SetPosition(1, fpsCam.transform.forward * boltRange);
            }
        }
    }

    private IEnumerator BoltEffect()
    {
        boltLine.enabled = true;
        yield return boltDuration;
        boltLine.enabled = false;

    }
}
