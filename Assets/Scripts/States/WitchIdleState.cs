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
    
    public void GoMove(InputManager.SingleKey.KeyType key)
    {
        InputManager.ComboRequest requestedCombo = LevelManager.current.selectedHouse.RequestedCombo;
        if (requestedCombo == null)
        {
            return;
        }

        if (requestedCombo.Progress(key))
        {
            // success
            switch (key)
            {
                case (InputManager.SingleKey.KeyType.O):
                    NextState = new WitchMoveBaseState(GO, InputManager.SingleKey.KeyType.O);
                    break;
                case (InputManager.SingleKey.KeyType.P):
                    NextState = new WitchMoveBaseState(GO, InputManager.SingleKey.KeyType.P);
                    break;
                case (InputManager.SingleKey.KeyType.K):
                    NextState = new WitchMoveBaseState(GO, InputManager.SingleKey.KeyType.K);
                    break;
                case (InputManager.SingleKey.KeyType.L):
                    NextState = new WitchMoveBaseState(GO, InputManager.SingleKey.KeyType.L);
                    break;
            }
            Stage = EVENT.EXIT;
        }
    }
}