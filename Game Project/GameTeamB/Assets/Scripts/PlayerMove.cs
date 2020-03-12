﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode boostKey;
    public bool dashing;
    public float dashTimerMax;
    public float dashTimer;
    public Vector2 direction = new Vector2(0, 0);
    Rigidbody2D r;
    Vector2 up;
    Vector2 down;
    Vector2 left;
    Vector2 right;
    bool pressing;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        up = Vector2.up;
        down = Vector2.down;
        left = Vector2.left;
        right = Vector2.right;
        dashTimer = dashTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        Move();
        Boosting();
    }
    void GetDirection()
    {
        pressing = false;
        if (Input.GetKey(upKey))
        {
            direction += up;
            pressing = true;
        }
        if (Input.GetKey(downKey))
        {
            direction += down;
            pressing = true;
        }
        if (Input.GetKey(leftKey))
        {
            direction += left;
            pressing = true;
        }
        if (Input.GetKey(rightKey))
        {
            direction += right;
            pressing = true;
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f);
        direction.Normalize();
    }
    void Move()
    {
        if (r.velocity.magnitude < speed)
        {
            dashing = false;
            if (pressing)
                r.velocity = direction * speed;
        }
        else
            dashing = true;
        if(dashTimer < 0.1f)
            r.velocity = direction * dashSpeed;
    }
    void Boosting()
    {
        if(Input.GetKeyDown(boostKey) && dashTimer == dashTimerMax)
        {
            dashTimer = 0;
        }
        if (dashTimer < dashTimerMax)
            dashTimer = Mathf.Clamp(dashTimer + Time.deltaTime, 0.0f, dashTimerMax);
    }
    void OnDestroy()
    {
        SceneManager.LoadScene("Main Level", LoadSceneMode.Single);
    }
}
