using UnityEngine;

public class WitchIdleState : WitchBaseState
{
    public WitchIdleState(GameObject go) : base(go)
    {
        StateName = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(IdleTrigger);
    }

    public void GoJump()
    {
        InputManager.ComboRequest requestedCombo = LevelManager.current.selectedHouse? LevelManager.current.selectedHouse.RequestedCombo : null;
        if (requestedCombo == null)
        {
            Debug.Log("requestedCombo null");
            return;
        }

        if (requestedCombo.Progress(InputManager.SingleKey.KeyType.SPACE))
        {
            Debug.Log("requestedCombo progress");
            NextState = new WitchJumpState(GO);
            Stage = EVENT.EXIT;
        }
    }
}