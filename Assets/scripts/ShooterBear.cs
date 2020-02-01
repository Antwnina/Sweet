using Assets.scripts;
using UnityEngine;

public class ShooterBear : MonoBehaviour
{

    public float speed;
    private Vector2 DirectionRight;
    private Rigidbody2D boltRigidBody2d;

    void Start()
    {
        if (GameObject.FindObjectOfType<bearController>().facingRight)
            DirectionRight = Vector2.right;
        else
            DirectionRight = Vector2.left;

        boltRigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        boltRigidBody2d.AddForce(DirectionRight * speed);

        Destroy(GameObject.Find("BoltBear(Clone)"), 1f);

    }

    void Update()
    {
        if (GameObject.FindObjectOfType<bearController>() != null)
            DirectionRight = (GameObject.FindObjectOfType<bearController>().facingRight ? Vector2.left : Vector2.right);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameHandler.HasBearLifes())
        {
            var fluffy = GameObject.FindObjectOfType<FluffyControl>();
            GameHandler.ReduceLife();
            fluffy.Die();
            Destroy(GameObject.Find ("BoltBear(Clone)"), 0.1f);

        }
    }


}