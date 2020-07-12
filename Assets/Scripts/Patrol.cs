﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2;
    private float currentSpeed;
    public float groundDistance = 2;
    public Transform detector;
    public bool movingRight = true;
    public float health;
    public float dazedTime;
    private float currentTime;
    public GameObject explosion;
    private void Start()
    {
        currentSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(detector.position, Vector2.down, groundDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D wallInfo;
        if (movingRight == true)
        {
            wallInfo = Physics2D.Raycast(detector.position, Vector2.right, 1f, ~LayerMask.GetMask("Player"));
        }
        else
        {
            wallInfo = Physics2D.Raycast(detector.position, Vector2.left, 1f, ~LayerMask.GetMask("Player"));
        }
        if (groundInfo == false || wallInfo == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        if (currentTime <= 0)
        {
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = 0;
            currentTime -= Time.deltaTime;
        }
    }
}
