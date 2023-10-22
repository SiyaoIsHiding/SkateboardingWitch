
using System;
using UnityEngine;

public class WitchBaseState
{
    [Serializable]
    public enum STATE
    {
        IDLE,
        O,
        P,
        K,
        L,
        JUMP,
        FALL,
        CAPTURE
    }
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
    protected WitchController Witch;
    protected WitchBaseState NextState;
    protected readonly int IdleTrigger = Animator.StringToHash("GoIdle");
    protected readonly int JumpTrigger = Animator.StringToHash("GoJump");
    protected readonly int OTrigger = Animator.StringToHash("GoO");
    protected readonly int PTrigger = Animator.StringToHash("GoP");
    protected readonly int KTrigger = Animator.StringToHash("GoK");
    protected readonly int LTrigger = Animator.StringToHash("GoL");
    protected readonly int FallTrigger = Animator.StringToHash("GoFall");
    protected readonly int CaptureTrigger = Animator.StringToHash("GoCaptureGhost");
    //TODO: edit animator
    
    public WitchBaseState(GameObject go)
    {
        GO = go;
        Anim = go.GetComponent<Animator>();
        Witch = go.GetComponent<WitchController>();
        Stage = EVENT.ENTER;
    }
    
    public virtual void Enter() { Stage = EVENT.UPDATE; }
    public virtual void Update() { Stage = EVENT.UPDATE; }
    public virtual void Exit() { Stage = EVENT.EXIT; }
    
    public WitchBaseState Process()
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