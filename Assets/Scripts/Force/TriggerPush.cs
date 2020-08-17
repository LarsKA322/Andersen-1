using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerPush : MonoBehaviour
{

    public float fanForce;
    // Start is called before the first frame update



    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            
            float distance = Vector3.Distance(transform.position, other.transform.position);
            float appliedForce = (distance * distance) / fanForce;
            Debug.Log("Distance: " + distance + " Appliedforce: " + appliedForce);
            other.attachedRigidbody.AddForce(transform.up * distance * fanForce);
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawCube(new Vector3(transform.localPosition.x, transform.localPosition.y + size / 2, transform.localPosition.z), new Vector3(transform.localScale.x, transform.localScale.y * size, transform.localScale.z));
    //}
}
