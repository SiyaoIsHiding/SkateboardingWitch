using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        // GameManager.current.OnJActions += HandleTrick;
        House.bubble.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        // GameManager.current.OnJActions -= HandleTrick;
        House.bubble.gameObject.SetActive(false);
    }

    private void HandleTrick(Null @null)
    {
        // check if its this house is selected
        if (LevelManager.current.selectedHouse.HouseId == House.HouseId)
        {
            GoNormal();
        }
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