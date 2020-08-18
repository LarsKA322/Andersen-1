using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{

    public float explosionTimer;



    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject, explosionTimer);
    }
}
