using Assets.scripts;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float speed;
    private Vector2 DirectionRight;
    private Rigidbody2D boltRigidBody2d;
    

    void Start()
    {
        if (GameObject.FindObjectOfType<FluffyControl>().FacingRight)
            DirectionRight = Vector2.right;
        else
            DirectionRight = Vector2.left;

        boltRigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        boltRigidBody2d.AddForce(DirectionRight * speed);
        

        Destroy(GameObject.Find("Bolt(Clone)"), 0.5f);
        
    }

    
    
    void Update()
    {
        DirectionRight = (GameObject.FindObjectOfType<FluffyControl>().FacingRight ? Vector2.left : Vector2.right);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Ghost")
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.Find("Bolt(Clone)"), 0.1f);
            GameHandler.AddScore(30);
        }
        if (collision.gameObject.tag == "Bear")
        {
            //Debug.Log(GameHandler.GetBearLifes());
            if (GameHandler.HasBearLifes() && GameHandler.GetBearLifes() > 1)
            {                
                GameHandler.ReduceBearLife();
                Destroy(GameObject.Find("Bolt(Clone)"), 0.1f);
            }            
            else if(GameHandler.HasBearLifes() && GameHandler.GetBearLifes() == 1)
            {
                GameHandler.ReduceBearLife();                
                Destroy(collision.gameObject);                
                GameHandler.AddScore(500);
                var particles = GameObject.FindObjectOfType<ParticleSystem>();
                particles.Play();                
                Destroy(GameObject.Find("Bolt(Clone)"), 0.1f);
           

            }

           
        }
    }

	

}
