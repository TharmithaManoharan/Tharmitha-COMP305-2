using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLitHandler : MonoBehaviour {

    public GameObject explosion;
	// Use this for initialization
	void Start () {
        Invoke("Explode", 3.0f);
        
	}
	
	// Update is called once per frame
	void Explode () {
        Instantiate(explosion, this.transform.position, this.transform.rotation);

	}
}
