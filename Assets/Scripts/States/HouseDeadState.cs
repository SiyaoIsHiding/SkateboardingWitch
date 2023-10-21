using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDeadState : HouseBaseState
{

    public HouseDeadState(GameObject go) : base(go)
    {
        StateName = STATE.DEAD;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(DeadTrigger);
    }

    

}