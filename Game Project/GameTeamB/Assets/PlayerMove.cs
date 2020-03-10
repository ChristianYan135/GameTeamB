using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boost;
    public bool dashing;
    Vector2 direction = new Vector2(0, 0);
    Rigidbody2D r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
    }
    void FixedUpdate()
    {
        Move();
    }
    void GetDirection()
    {
        direction = new Vector2(0, 0);
        if (Input.GetKey(up))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(down))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(left))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(right))
        {
            direction += Vector2.right;
        }
        direction.Normalize();
    }
    void Move()
    {
        r.velocity = direction * speed;
    }
    void Boosting()
    {
        if(Input.GetKeyDown(boost))
        {
            r.AddForce(direction * dashSpeed);
        }
    }
}
