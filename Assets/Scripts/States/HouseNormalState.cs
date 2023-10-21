using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseNormalState : HouseBaseState
{
    private bool startWithRequest = false;

    public HouseNormalState(GameObject go, bool _startWithRequest = false) : base(go)
    {
        StateName = STATE.NORMAL;
        startWithRequest = _startWithRequest;
        Debug.Log("HouseNormalState constructor");
    }

    public override void Enter()
    {
        base.Enter();
        if (startWithRequest)
        {
            GoRequest();
        }
        else
        {
            Anim.SetTrigger(NormalTrigger);
            House.StartCoroutine(RandomlyGoRequest());
        }
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
        GoRequest();
    }
}
