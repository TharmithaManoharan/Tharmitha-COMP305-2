using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject: MonoBehaviour
{

    public int objects;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object is a player, then do destroy the objects
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController05>().CollectObject(objects);
            Destroy(this.gameObject);
        }
    }
}
