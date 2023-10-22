using System.Collections;
using UnityEngine;

public class WitchFallState : WitchBaseState
{
    public WitchFallState(GameObject go) : base(go)
    {
        StateName = STATE.FALL;
    }
    
    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(FallTrigger);
        Witch.StartCoroutine(NaturallyEnds());
    }

    public override void Exit()
    {
        base.Exit();
        Witch.FallOnLeft();
    }

    private IEnumerator NaturallyEnds()
    {
        yield return new WaitForSeconds(Constants.Witch.FALL_TIME);
        NextState = new WitchIdleState(GO);
        Stage = EVENT.EXIT;
    }
}