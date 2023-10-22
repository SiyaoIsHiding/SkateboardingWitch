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
        GameManager.current.jump.Play();
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
            GoFall();
        }
        Stage = EVENT.EXIT;
    }
    
    public void GoFall()
    {
        NextState = new WitchFallState(GO);
        Stage = EVENT.EXIT;
    }

    IEnumerator NaturallyEnds()
    {
        yield return new WaitForSeconds(Constants.Witch.JUMP_END_TIME);
        if (Witch.WitchState == this)
        {
            GoFall();
            requestedCombo?.ProgressUnintendedIdle();
        }
    }
}