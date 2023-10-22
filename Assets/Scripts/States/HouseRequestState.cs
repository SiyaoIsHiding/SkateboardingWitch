using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseRequestState : HouseBaseState
{
    public HouseRequestState(GameObject go) : base(go)
    {
        StateName = STATE.REQUEST;
    }

    public override void Enter()
    {
        base.Enter();
        Anim.SetTrigger(RequestTrigger);
        House.bubble.gameObject.SetActive(true);
        InputManager.PresetCombo combo = InputManager.PresetCombo.PresetCombos[Random.Range(0, InputManager.PresetCombo.PresetCombos.Count)];
        House.RequestedCombo = new InputManager.ComboRequest(combo);
        House.RequestedCombo.OnTrickComplete += HandleTrick;
        House.RequestedCombo.OnTrickFailed += (@null => { Debug.Log("Trick failed"); });
        Debug.Log("Requested combo: " + House.RequestedCombo.Combo.ToString());
        // list the SingleKey in the combo
        string comboString = "";
        comboString += House.HouseId.ToString() + "  ";
        foreach (InputManager.SingleKey.KeyType key in House.RequestedCombo.Combo.KeySequence)
        {
            comboString += key.ToString() + " ";
        }
        Debug.Log(comboString);
    }

    public override void Exit()
    {
        base.Exit();
        House.bubble.gameObject.SetActive(false);
    }

    private void HandleTrick(Null @null)
    {
        // check if its this house is selected
        if (LevelManager.current.selectedHouse.HouseId == House.HouseId)
        {
            GoNormal();
        }
    }
    /**
     * Got satisfied. Cheers, and drop candy.
     */
    public void GoNormal()
    {
        NextState = new HouseNormalState(GO);
        Stage = EVENT.EXIT;
        DropCandy();
    }

    private void DropCandy()
    {
        GameObject candy = House.candy.gameObject;
        candy.SetActive(true);
    }
}