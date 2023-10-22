using System.Collections;
using UnityEngine;

public class HauntHauntingState : HauntBaseState
{
    public HauntHauntingState(GameObject go) : base(go)
    {
        StateName = STATE.HAUNTING;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(HauntingTrigger);
        LevelManager.current.ReadyHauntHouses.Remove(Haunt.house.HouseId);
    }

    public override void Exit()
    {
        base.Exit();
        LevelManager.current.ReadyHauntHouses.Add(Haunt.house.HouseId, Haunt.house);
    }

    public void GoCaptured()
    {
        NextState = new HauntCapturedState(GO);
        Stage = EVENT.EXIT;
    }

    public void GoHaunted()
    {
        NextState = new HauntHauntedState(GO);
        Stage = EVENT.EXIT;
    }

    private IEnumerator NaturallyHaunted()
    {
        yield return new WaitForSeconds(Constants.House.GO_HAUNTED_TIME);
        if (Haunt.CurrentState == this)
            GoHaunted();
    }
}