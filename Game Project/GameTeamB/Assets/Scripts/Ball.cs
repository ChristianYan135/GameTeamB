using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 1.0f;

    public float speedM = 1.0f;

    Rigidbody2D rigidbody2d;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        rigidbody2d.velocity = Vector2.right * startSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            
        }
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            rigidbody2d.velocity *= speedM;
            transform.rotation = col.collider.gameObject.transform.rotation;
            renderer.color = Color.blue;
        }
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Player2"))
        {
            rigidbody2d.velocity *= speedM;
            transform.rotation = col.collider.gameObject.transform.rotation;
            renderer.color = Color.red;
        }
    }
}
