using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<Vector2> OnMoveActions;

    public void TriggerOnMoveActions(Vector2 direction)
    {
        OnMoveActions?.Invoke(direction);
    }

    void Start()
    {
    }
    
    void Update()
    {
    }

    private void OnMove(InputValue input)
    {
        TriggerOnMoveActions(input.Get<Vector2>());
    }

    #region tricks
    public enum Trick
    {
        OLLIE,
        KICKFLIP,
        GRAB,
        SHOVEIT
    }
    
    public enum TrickKey
    {
        SPACE,
        O,
        K,
        L,
        P
    }
    public event Action<Null> OnOllie;
    public event Action<Null> OnKickflip;
    public event Action<Null> OnGrab;
    public event Action<Null> OnShoveit;
    private Dictionary<TrickKey, bool> trickKeyStatus = new Dictionary<TrickKey, bool>();
    
    private void OnSpace(InputAction.CallbackContext context)
    {
        Debug.Log(context);   
        // CheckTrick();
    }
    
    
    private void CheckTrick()
    {
        // print the dictionary
        foreach (var pair in trickKeyStatus)
        {
            print(pair.Key + " " + pair.Value);
        }
    }
    
    #endregion
}