using Assets.scripts;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public static Vector3 ReachedPoint { get; private set; }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fluffy")
        {
            if (collision.gameObject.transform.position.x > ReachedPoint.x)
            {
                ReachedPoint = collision.gameObject.transform.position;
            }
        }

    }

  
}
