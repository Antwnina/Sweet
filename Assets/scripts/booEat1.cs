using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booEat1 : MonoBehaviour {

	public GameObject target;
	public float ratio = 0.05f;

	private Animator BooAnimator; //Animator

	// Use this for initialization
	void Start () {
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
		
			//BooAnimator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, ratio);

	}

}