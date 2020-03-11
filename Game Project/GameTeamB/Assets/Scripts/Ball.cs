using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 startSpeed = new Vector2(1.0f,1.0f);

    public float speedM = 1.0f;

    int timesHit = 1;

    int turn = 0;
    Rigidbody2D rigidbody2d;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidbody2d.velocity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            if (col.collider.gameObject.GetComponent<PlayerMove>().dashing)
            {
                rigidbody2d.velocity = startSpeed * (speedM * timesHit);
                transform.rotation = col.collider.gameObject.transform.rotation;
                renderer.color = Color.blue;
                timesHit++;
                turn = 1;
            }
            else if(!col.collider.gameObject.GetComponent<PlayerMove>().dashing && turn == 2)
            {
                Destroy(col.collider.gameObject);
            }
            
        }
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Player2"))
        {
            if (col.collider.gameObject.GetComponent<PlayerMove>().dashing)
            {
                rigidbody2d.velocity = startSpeed * (speedM * timesHit);
                transform.rotation = col.collider.gameObject.transform.rotation;
                renderer.color = Color.red;
                timesHit++;
                turn = 2;
            }
            else if (!col.collider.gameObject.GetComponent<PlayerMove>().dashing && turn == 1)
            {
                Destroy(col.collider.gameObject);
            }
        }
    }
}
