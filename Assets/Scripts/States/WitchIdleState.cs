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
        Debug.LogWarning("Set IdleTrigger");
    }

    public void GoJump()
    {
        InputManager.ComboRequest requestedCombo = LevelManager.current.selectedHouse
            ? LevelManager.current.selectedHouse.RequestedCombo
            : null;
        if (requestedCombo == null)
        {
            return;
        }

        if (requestedCombo.Progress(InputManager.SingleKey.KeyType.SPACE))
        {
            NextState = new WitchJumpState(GO);
            Stage = EVENT.EXIT;
        }
    }

    public void GoCapture()
    {
        bool isCaptured = LevelManager.current.Capture();
        if (isCaptured)
        {
            Debug.Log("WitchIdleState GoCapture called");
            NextState = new WitchCaptureState(GO);
            Stage = EVENT.EXIT;
        }
    }
}