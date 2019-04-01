using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Вращение астероида
public class RotatorRandom_script : MonoBehaviour {
    public float tumble;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
