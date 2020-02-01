using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class bearController : MonoBehaviour {

	private float HSpeed = 0.001f;
    
	//private float maxVertHSpeed = 20f;
	public bool facingRight = true;
    private bool nearFluffy = false;
	private float moveXInput;

    //Used for flipping Character Direction
	public static Vector3 theScale;
    public static Vector3 lastPos;

    //Jumping Stuff
    public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
    private DateTime started = DateTime.Now;
    private float groundRadius = 0.15f;
	private float jumpForce = 14f;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Animator anim;
    private Transform target;

    // Use this for initialization
    void Awake ()
	{
        nearFluffy = false;
        anim = GetComponent<Animator>();
        lastPos = transform.position;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
 
	void FixedUpdate ()
	{

        nearFluffy = GameObject.FindGameObjectWithTag("Player").GetComponent<FluffyControl>().groundBearTouched;
     //   Debug.Log(nearFluffy.ToString());
        if (nearFluffy)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("ground", grounded);
        }
        else
        {
            anim.SetBool("ground", false);
        }
    }

  

    private void Shoot()
    {
        anim.SetTrigger("Punch");
        // anim.SetTrigger("BearShoot");
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    void Update()
	{

        nearFluffy = GameObject.FindGameObjectWithTag("Player").GetComponent<FluffyControl>().groundBearTouched;
     //   Debug.Log(nearFluffy.ToString());
        if (nearFluffy)
            BearAi();
    }
    ////Flipping direction of character
    void Flip()
	{
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    private void BearAi()
    {
        if ((DateTime.Now - started).TotalSeconds > 2)
        {
            Shoot();
            started = DateTime.Now;

        }

        anim.SetFloat("HSpeed", 0.6f);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);


        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Sprint", true);
            HSpeed = 14f;
        }
        else
        {
            anim.SetBool("Sprint", false);
            HSpeed = 10f;
        }
        //Flipping direction character is facing based on players Input
        if ((transform.position - lastPos).x > 0 && !facingRight)
            Flip();
        else if ((transform.position - lastPos).x < 0 && facingRight)
            Flip();
        lastPos = transform.position;
    }
}
