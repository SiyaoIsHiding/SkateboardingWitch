using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WitchController : MonoBehaviour
{
    
    private Vector2 move;
    private Rigidbody2D rb;
    private float speed = 5f;
    public WitchBaseState WitchState;
    private Animator _animator;
    // private readonly 
    public string StateName; // DEBUG ONLY

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        WitchState = new WitchIdleState(gameObject);
    }
    
    void Update()
    {
        rb.velocity = move * speed;
        WitchState = WitchState.Process();
        StateName = WitchState.StateName.ToString();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        // _animator.SetFloat();
    }
    
    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (WitchState is WitchIdleState)
            {
                ((WitchIdleState) WitchState).GoJump();
            }
        }
    }
    
    public void OnO(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (WitchState is WitchJumpState)
            {
                ((WitchJumpState) WitchState).GoMove(InputManager.SingleKey.KeyType.O);
            }
            else if (WitchState is WitchMoveBaseState)
            {
                ((WitchMoveBaseState) WitchState).GoMove(InputManager.SingleKey.KeyType.O);
            }
        }
    }
    
    public void OnK(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (WitchState is WitchJumpState)
            {
                ((WitchJumpState) WitchState).GoMove(InputManager.SingleKey.KeyType.K);
            }
            else if (WitchState is WitchMoveBaseState)
            {
                ((WitchMoveBaseState) WitchState).GoMove(InputManager.SingleKey.KeyType.K);
            }
        }
    }
    
    public void OnL(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (WitchState is WitchJumpState)
            {
                ((WitchJumpState) WitchState).GoMove(InputManager.SingleKey.KeyType.L);
            }
            else if (WitchState is WitchMoveBaseState)
            {
                ((WitchMoveBaseState) WitchState).GoMove(InputManager.SingleKey.KeyType.L);
            }
        }
    }
    
    public void OnP(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (WitchState is WitchJumpState)
            {
                ((WitchJumpState) WitchState).GoMove(InputManager.SingleKey.KeyType.P);
            }
            else if (WitchState is WitchMoveBaseState)
            {
                ((WitchMoveBaseState) WitchState).GoMove(InputManager.SingleKey.KeyType.P);
            }
        }
    }
    
}