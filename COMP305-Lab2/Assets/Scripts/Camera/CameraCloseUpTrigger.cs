using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloseUpTrigger : MonoBehaviour {


    public Camera mainCamera;
    public Camera closeUpCamera;

    //definded by unity
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            closeUpCamera.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        closeUpCamera.enabled = false;
        mainCamera.enabled = true;
    }

}
