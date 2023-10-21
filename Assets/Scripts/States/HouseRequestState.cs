using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRequestState : HouseBaseState
{
    public HouseRequestState(GameObject go) : base(go)
    {
        StateName = STATE.REQUEST;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(RequestTrigger);
        GameManager.current.OnJActions += (Null => { GoNormal(); });
        House.bubble.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.current.OnJActions -= (Null => { GoNormal(); });
        House.bubble.gameObject.SetActive(false);
    }

    /**
     * Got satisfied. Cheers, and drop candy.
     */
    public void GoNormal()
    {
        NextState = new HouseNormalState(GO);
        Stage = EVENT.EXIT;
        DropCandy();
    }

    private void DropCandy()
    {
        GameObject candy = House.candy.gameObject;
        candy.SetActive(true);
    }
}