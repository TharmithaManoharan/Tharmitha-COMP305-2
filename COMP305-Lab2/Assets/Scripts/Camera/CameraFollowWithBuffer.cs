using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour {

    public Transform playerPosition;
    public Transform playerMoveTreshold;

	// Use this for initialization
	void Start () {
        playerMoveTreshold = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (playerPosition.position.x > playerMoveTreshold.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        }
	}
    //predefined unity function for drawing gizmos in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerMoveTreshold.position, new Vector3(playerMoveTreshold.position.x, playerMoveTreshold.position.y + 100, playerMoveTreshold.position.z));
        Gizmos.DrawLine(playerMoveTreshold.position, new Vector3(playerMoveTreshold.position.x, playerMoveTreshold.position.y - 100, playerMoveTreshold.position.z));
    }
}
