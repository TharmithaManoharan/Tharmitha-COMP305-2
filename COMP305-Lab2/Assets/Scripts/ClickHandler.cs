using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

    public GameObject gBlue;
    public Sprite fSprite;

    private SpriteRenderer sRend;
	// Use this for initialization
	void Start () {
        
         sRend = gBlue.GetComponent<SpriteRenderer>();
    }
    //executes when a mouse down event is fires on the attached object
    void OnMouseDown()
    {
        sRend.sprite = fSprite;
       
    }
}
