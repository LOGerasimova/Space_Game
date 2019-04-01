using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour {
    public float speed;

    //направление движения пули
	void Update ()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
