using UnityEngine;

public class HauntBaseState
{
    public enum STATE
    {
        NORMAL,
        HAUNTING,
        CAPTURED,
        HAUNTED
    }
    
    protected readonly int HauntingTrigger = Animator.StringToHash("GoHaunting");
    protected readonly int CapturedTrigger = Animator.StringToHash("GoCaptured");
    protected readonly int HauntedTrigger = Animator.StringToHash("GoHaunted");
    
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
    protected Haunt Haunt;
    protected HauntBaseState NextState;
    
    public HauntBaseState(GameObject go)
    {
        GO = go;
        Haunt = go.GetComponent<Haunt>();
        Anim = Haunt.ghostAnim;
        Stage = EVENT.ENTER;
    }
    
    public virtual void Enter() { Stage = EVENT.UPDATE; }
    public virtual void Update() { Stage = EVENT.UPDATE; }
    public virtual void Exit() { Stage = EVENT.EXIT; }
    
    public HauntBaseState Process()
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