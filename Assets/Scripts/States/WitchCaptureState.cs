using UnityEngine;
using System.Collections;

public class WitchCaptureState : WitchBaseState
{
    public WitchCaptureState(GameObject go) : base(go)
    {
        StateName = STATE.CAPTURE;
    }
    
    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(CaptureTrigger);
        Witch.StayStill();
        Witch.StartCoroutine(NaturallyEnds());
    }
    
    private void GoIdle()
    {
        Witch.StayStill();
        NextState = new WitchIdleState(GO);
        Stage = EVENT.EXIT;
    }
    
    
    private IEnumerator NaturallyEnds()
    {
        yield return new WaitForSeconds(Constants.Witch.CAPTURE_TIME);
        GoIdle();
    }
}