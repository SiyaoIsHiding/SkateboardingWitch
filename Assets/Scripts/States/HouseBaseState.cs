using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBaseState
{
    [Serializable]
    public enum STATE
    {
        NORMAL,
        REQUEST,
        DEAD
    }
    
    protected readonly int NormalTrigger = Animator.StringToHash("GoNormal");
    protected readonly int RequestTrigger = Animator.StringToHash("GoRequest");
    protected readonly int DeadTrigger = Animator.StringToHash("GoDead");

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public STATE StateName;
    protected EVENT Stage;
    protected Animator Anim;
    protected GameObject GO;
    protected House House;
    protected HouseBaseState NextState;

    public HouseBaseState(GameObject go)
    {
        GO = go;
        Anim = go.GetComponent<Animator>();
        House = go.GetComponent<House>();
        Stage = EVENT.ENTER;
    }
    
    public virtual void Enter() { Stage = EVENT.UPDATE; }
    public virtual void Update() { Stage = EVENT.UPDATE; }
    public virtual void Exit() { Stage = EVENT.EXIT; }

    public HouseBaseState Process()
    {
        switch (Stage)
        {
            case EVENT.ENTER:
                Enter();
                break;
            case EVENT.UPDATE:
                Update();
                break;
            case EVENT.EXIT:
                Exit();
                return NextState;
        }

        return this;
    }
}
