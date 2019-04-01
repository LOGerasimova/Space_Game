using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_script : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    public BaunDaru baundaru;
    Vector3 V3m;
    public GameObject bullet;
    public Transform spawnBullet;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    //Управление кораблем
    void FixedUpdate()
    {
        V3m = transform.position;

        if (Input.GetKey(KeyCode.W))
            transform.position = new Vector3(V3m.x, -0.6f, V3m.z + speed);
        if (Input.GetKey(KeyCode.S))
            transform.position = new Vector3(V3m.x, -0.6f, V3m.z - speed);
        if (Input.GetKey(KeyCode.A))
            transform.position = new Vector3(V3m.x - speed, -0.6f, V3m.z);
        if (Input.GetKey(KeyCode.D))
            transform.position = new Vector3(V3m.x + speed, -0.6f, V3m.z);

        if (Input.GetMouseButtonDown(0))
            Bollet();

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, baundaru.xMin, baundaru.xMax),
                -0.6f,
                Mathf.Clamp(rb.position.z, baundaru.zMin, baundaru.zMax)
            );
    }

    //Создание пуль
    void Bollet()
    {
        GameObject clone = Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation) as GameObject;
    }  
}

[System.Serializable]
public class BaunDaru
{
    public float xMin, xMax, zMin, zMax;
}