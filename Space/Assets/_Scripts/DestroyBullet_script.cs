using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet_script : MonoBehaviour {

    //уничтожение любого объека, вышедшего за пределы игрового поля
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
