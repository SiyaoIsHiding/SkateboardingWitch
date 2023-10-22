using System.Collections;
using UnityEngine;

public class WitchMoveBaseState : WitchBaseState
{
    public InputManager.ComboRequest requestedCombo;
    public InputManager.SingleKey.KeyType Key;
    public WitchMoveBaseState(GameObject go, InputManager.SingleKey.KeyType key) : base(go)
    {
        Key = key;
        switch (key)
        {
            case (InputManager.SingleKey.KeyType.O):
                StateName = STATE.O;
                break;
            case (InputManager.SingleKey.KeyType.P):
                StateName = STATE.P;
                break;
            case (InputManager.SingleKey.KeyType.K):
                StateName = STATE.K;
                break;
            case (InputManager.SingleKey.KeyType.L):
                StateName = STATE.L;
                break;
        }

        requestedCombo = LevelManager.current.selectedHouse.RequestedCombo;
    }

    public override void Enter()
    {
        base.Enter();
        switch (Key)
        {
            case (InputManager.SingleKey.KeyType.O):
                Anim.SetTrigger(OTrigger);
                break;
            case (InputManager.SingleKey.KeyType.P):
                Anim.SetTrigger(PTrigger);
                break;
            case (InputManager.SingleKey.KeyType.K):
                Anim.SetTrigger(KTrigger);
                break;
            case (InputManager.SingleKey.KeyType.L):
                Anim.SetTrigger(LTrigger);
                break;
        }
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
        yield return new WaitForSeconds(Constants.Trick.MOVE_END_TIME);
        if (Witch.WitchState == this)
        {
            GoIdle();
        }
    }
}