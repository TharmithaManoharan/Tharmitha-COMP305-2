using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour {

    // Use this for initialization
    public GameObject plusOne;

        void Explode()
    {
       
        Instantiate(plusOne, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
