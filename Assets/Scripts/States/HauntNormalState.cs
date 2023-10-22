

using UnityEngine;

public class HauntNormalState : HauntBaseState
{
    public HauntNormalState(GameObject go) : base(go)
    {
        StateName = STATE.NORMAL;
    }

    public void GoHaunting()
    {
        NextState = new HauntHauntingState(GO);
        Stage = EVENT.EXIT;
    }
}