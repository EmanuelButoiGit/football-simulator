using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody ballRb;
    public float forceMultiplier;

    void OnCollisionEnter(Collision other)
    {
        ballRb.AddForce(transform.forward * forceMultiplier);
    }
}
