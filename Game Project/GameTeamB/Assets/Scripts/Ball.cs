using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 startSpeed = new Vector2(1.0f,1.0f);

    public float speedM = 1.0f;

    int timesHit = 1;

    int turn = 0;

    public GameObject bottomBall;

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
        Debug.Log(turn);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("TEST");
        if (col.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            if (col.gameObject.GetComponent<PlayerMove>().dashing)
            {
                rigidbody2d.velocity = startSpeed * (speedM * timesHit);
                transform.rotation = col.gameObject.transform.rotation;
                renderer.color = Color.blue;
                timesHit++;
                turn = 1;
            }
            else if(!col.gameObject.GetComponent<PlayerMove>().dashing && turn == 2)
            {
                Destroy(col.gameObject);
            }
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Player2"))
        {
            if (col.gameObject.GetComponent<PlayerMove>().dashing)
            {
                rigidbody2d.velocity = startSpeed * (speedM * timesHit);
                transform.rotation = col.gameObject.transform.rotation;
                renderer.color = Color.red;
                timesHit++;
                turn = 2;
            }
            else if (!col.gameObject.GetComponent<PlayerMove>().dashing && turn == 1)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
