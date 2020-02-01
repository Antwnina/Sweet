using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");    
	}
	
	// Update is called once per frame
	void LateUpdate () {
        
       // float x = Mathf.Clamp(player.transform.position.x, -2, 0);        
        
        gameObject.transform.position = new Vector3(player.transform.position.x+4f, player.transform.position.y/4, gameObject.transform.position.z);
	}
}
	