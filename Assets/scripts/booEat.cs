using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booEat : MonoBehaviour {

	public GameObject target;
	public float ratio = 0.05f;

	private Animator BooAnimator; //Animator

	//float distance = Vector3.Distance(booEat.transform.position, target.transform.position);//calculate distance between them
	//float distance = booEat.transform.position - target.transform.position;//calculate distance between them

	// Use this for initialization
	void Start () {
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
		
			BooAnimator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, ratio);

		/*EatAnim(false);

		if (distance <0.1f)
			EatAnim(true); */
	}

	/*#region Animations

	private void EatAnim(bool applyEat)
	{       
		BooAnimator.SetBool("ApplyingEat", applyEat);        
	}
	#endregion */
}