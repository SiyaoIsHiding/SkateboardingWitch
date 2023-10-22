using UnityEngine;

public class HauntHauntedState : HauntBaseState
{
    public HauntHauntedState(GameObject go) : base(go)
    {
        StateName = STATE.HAUNTED;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(HauntedTrigger);
        Haunt.house.HouseState.GoDead();
    }
}