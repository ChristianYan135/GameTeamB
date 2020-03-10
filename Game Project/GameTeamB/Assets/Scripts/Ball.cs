using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 1.0f;

    float speedM = 1.0f;

    Rigidbody2D rigidbody2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = Vector2.right * startSpeed * speedM;
    }

    // Update is called once per frame
    void Update()
    {
       // rigidbody2d.velocity = Vector2.up * startSpeed * speedM;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            
        }
    }
}
