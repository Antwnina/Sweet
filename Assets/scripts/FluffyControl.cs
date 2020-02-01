using Assets.scripts;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FluffyControl : MonoBehaviour
{
    public int FluffySpeed = 5;
    public bool FacingRight = true;

    [Range(5,15)]
    public float PlayerJumpPower;

    private Rigidbody2D playerRigidBody2d;
    private bool groundTouched;
    public bool groundBearTouched;
    private bool startCollected;
    private bool IsOnBearGround = false;
    private Animator fluffyAnimator; //Animator

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public AudioSource jumbSound;
    public GameObject axe;


    public void PlayGame()
    {
        SceneManager.LoadScene("Chocolate");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void Start()
    {
        if(GameHandler.HasCheckpoint)
        {
            gameObject.transform.position = GameHandler.LatestCheckpointPosition;
        }
        playerRigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        fluffyAnimator = gameObject.GetComponent<Animator>();
        groundTouched = true;
        groundBearTouched = false;
        startCollected = false;
        SetCanvasText();        

    }  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundTouched = true;
            groundBearTouched = false;
            JumpAnim(false);
        }

        if (collision.gameObject.tag == "GroundBear")
        {            
            groundTouched = true;
            groundBearTouched = true;
            IsOnBearGround = true;
            JumpAnim(false);
        }

        if (collision.gameObject.tag == "PickUps")
        {
            GameHandler.AddScore(10);
            Destroy(collision.gameObject);           
        }
        if (collision.gameObject.tag == "ChocolateDoor")
        {
            GameHandler.HasCheckpoint = false;
            SceneManager.LoadScene("Candy");
        }
        if (collision.gameObject.tag == "CandyDoor")
        {
            GameHandler.HasCheckpoint = false;
            SceneManager.LoadScene("Marshmallow");
        }
        if (collision.gameObject.tag == "FinalDoor")
        {
            GameHandler.HasCheckpoint = false;
            SceneManager.LoadScene("FinalStage");
        }
        if (collision.gameObject.tag == "Star")
        {
            startCollected = true;
            GameHandler.AddScore(20);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Life")
        {
            Destroy(collision.gameObject);            
            GameHandler.AddLife();
            
        }

        if (collision.gameObject.tag == "Bear" && GameHandler.HasLifes())
        {
            GameHandler.ReduceLife();
            Die();
        }

        if (collision.gameObject.tag == "Ghost" && GameHandler.HasLifes())
        {
            GameHandler.ReduceLife();
            Die();
        }
        if (collision.gameObject.tag == "LoseBar")
        {
            GameHandler.ReduceLife();
            Die();
        }

        if (collision.gameObject.tag== "Checkpoint")
        {
           GameHandler.HasCheckpoint = true;
           GameHandler.LatestCheckpointPosition= collision.gameObject.transform.position;
            GameHandler.AddScore(30);
            Destroy(collision.gameObject);
        }

        SetCanvasText();
    }
    private void SetCanvasText()
    {
        var sb = new StringBuilder().AppendLine();
        sb.AppendLine("     Life: " + GameHandler.GetLifes());
         sb.AppendLine("     Score: " + GameHandler.GetScore());
        if(IsOnBearGround)
        {
            sb.AppendLine("Bear Lifes: " + GameHandler.GetBearLifes());
        }
      
        GameObject.FindObjectOfType<Text>().text = sb.ToString();
    }

    public void Die()
    {
        
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(Application.loadedLevelName);
        
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

		if (GameHandler.HasLifes ()) {
			SetCanvasText ();
			if (groundTouched && Input.GetKeyDown (KeyCode.UpArrow)) {                
				Jump ();               
				jumbSound.Play ();
				groundTouched = false;
			}

			if (startCollected && Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
				Shoot ();
			}

			FluffyMove ();

		}
    }

   

    private void FluffyMove()
    {
        if (Input.GetAxis("Horizontal") < 0.0f && FacingRight == true)
        {
            FlipPlayer();
        }
        else if (Input.GetAxis("Horizontal") > 0.0f && FacingRight == false)
        {
            FlipPlayer();
        }
        Walk();
        //checks if the player movies on the Horizontal axis and multiplies the velocity with the speed to move
        playerRigidBody2d.velocity = new Vector2(Input.GetAxis("Horizontal") * FluffySpeed, playerRigidBody2d.velocity.y); 
            

    }

    private void Walk()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && groundTouched)
            WalkAnim(true);
        else
            WalkAnim(false);
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerJumpPower;
        JumpAnim(true);
        groundTouched = false;

    }

    private void FlipPlayer()   
    {
        FacingRight = !FacingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    #region Animations

    private void JumpAnim(bool applyJump)
    {       
        fluffyAnimator.SetBool("ApplyingJump", applyJump);        
    }

    private void WalkAnim(bool applyWalk)
    {        
        fluffyAnimator.SetBool("ApplyingWalk", applyWalk);
    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
    #endregion
 

}
