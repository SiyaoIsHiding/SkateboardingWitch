using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHauntingState : HouseBaseState
{
    //TODO: Haunting states

    public HouseHauntingState(GameObject go) : base(go)
    {
        StateName = STATE.HAUNTING;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(DeadTrigger);
    }

    

}