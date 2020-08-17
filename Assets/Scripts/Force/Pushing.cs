using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{

    public float _radius = 10f;
    public float _windAmount;

    public void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapCapsule(transform.localPosition + Vector3.up *3, transform.localPosition + Vector3.up * _windAmount, _radius);
        if(hitColliders != null) {
            foreach (var hitCollider in hitColliders)
            {   
                Debug.Log(hitCollider.name);
                Rigidbody _body = hitCollider.GetComponent<Rigidbody>();
                Vector3 direction = _body.transform.position - hitCollider.transform.position;
                _body.AddForceAtPosition(_windAmount * Vector3.up, hitCollider.transform.position);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.localPosition + Vector3.up * 3, transform.localPosition + Vector3.up * _windAmount);
    }
}
