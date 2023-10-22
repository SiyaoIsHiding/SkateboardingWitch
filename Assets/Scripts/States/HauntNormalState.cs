

using UnityEngine;

public class HauntedNormalState : HauntBaseState
{
    public HauntedNormalState(GameObject go) : base(go)
    {
        StateName = STATE.NORMAL;
    }

    public void GoHaunting()
    {
        //TODO: GoHaunting mechanism
        NextState = new HauntHauntingState(GO);
        Stage = EVENT.EXIT;
    }
}