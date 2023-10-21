using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    
    private Vector2 move;
    private Rigidbody2D rb;
    private float speed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameManager.current.OnMoveActions += ToMove;
    }
    
    void Update()
    {
        rb.velocity = move * speed;
    }

    void ToMove(Vector2 mv)
    {
        move = mv;
    }
}