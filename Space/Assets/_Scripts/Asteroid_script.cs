using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_script : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

    //направление астероида
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

}
