using System.Collections;
using UnityEngine;

public class WitchJumpState : WitchBaseState
{
    public InputManager.ComboRequest requestedCombo;
    public WitchJumpState(GameObject go) : base(go)
    {
        StateName = STATE.JUMP;
        requestedCombo = LevelManager.current.selectedHouse.RequestedCombo;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.ResetTrigger(IdleTrigger);
        Anim.SetTrigger(JumpTrigger);
        Witch.StartCoroutine(NaturallyEnds());
    }
    
    public void GoMove(InputManager.SingleKey.KeyType key)
    {
        // NextState = 
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
        }
        else
        {
            // fail
            GoIdle();
        }
        Stage = EVENT.EXIT;
    }
    
    public void GoIdle()
    {
        NextState = new WitchIdleState(GO);
        Stage = EVENT.EXIT;
    }

    IEnumerator NaturallyEnds()
    {
        yield return new WaitForSeconds(Constants.Trick.JUMP_END_TIME);
        if (Witch.WitchState == this)
        {
            GoIdle();
        }
    }
}