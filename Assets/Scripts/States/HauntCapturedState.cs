
using UnityEngine;

public class HauntCapturedState : HauntBaseState
{
    public HauntCapturedState(GameObject go) : base(go)
    {
        StateName = STATE.CAPTURED;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(CapturedTrigger);
    }
}