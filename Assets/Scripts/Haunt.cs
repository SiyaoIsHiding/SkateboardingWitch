

using System;
using UnityEngine;

public class Haunt : MonoBehaviour
{
    public HauntBaseState CurrentState;
    public string StateName; // DEBUG ONLY
    public House house;
    public Animator ghostAnim;
    private void Awake()  
    {
        CurrentState = new HauntNormalState(gameObject);
    }

    private void Start()
    {
    }

    private void Update()
    {
        StateName = CurrentState.StateName.ToString();
        CurrentState = CurrentState.Process();
    }
}