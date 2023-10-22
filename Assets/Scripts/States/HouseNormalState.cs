using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseNormalState : HouseBaseState
{
    public HouseNormalState(GameObject go) : base(go)
    {
        StateName = STATE.NORMAL;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(NormalTrigger);
        House.StartCoroutine(RandomlyGoRequest());
    }

    public void GoRequest()
    {
        NextState = new HouseRequestState(GO);
        Stage = EVENT.EXIT;
    }

    private IEnumerator RandomlyGoRequest()
    {
        yield return new WaitForSeconds(Random.Range
            (Constants.House.RANDOM_GOREQUEST_MIN_TIME, Constants.House.RANDOM_GOREQUEST_MAX_TIME));
        if (House.HouseState == this)
            GoRequest();
    }
}