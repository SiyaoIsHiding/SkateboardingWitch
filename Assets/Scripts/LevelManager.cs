using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public float spellMeterValue = 0f;
    public House selectedHouse;
    public SpellMeter spellMeter;
    public House[] allHouses;
    public Dictionary<int, House> ReadyHauntHouses = new Dictionary<int, House>();
    public Dictionary<int, House> ReadyRequestHouses = new Dictionary<int, House>();

    private void Awake()
    {
        current = this;
        selectedHouse = null;
    }

    void Start()
    {
        foreach (var h in allHouses)
        {
            ReadyHauntHouses.Add(h.HouseId, h);
            ReadyRequestHouses.Add(h.HouseId, h);
        }

        for (int i = 0; i < Constants.House.INITIAL_REQUEST_COUNT; i++)
        {
            House h = GetRandomHouse(ReadyRequestHouses);
            ((HouseNormalState) h.HouseState).GoRequest();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void CandyCollected()
    {
        spellMeter.AdjustSpellMeter(spellMeterValue + 0.2f);
        spellMeterValue = spellMeter.GetSpellMeter();
    }
    
    private House GetRandomHouse(Dictionary<int, House> houses)
    {
        int index = UnityEngine.Random.Range(0, houses.Count);
        House house = houses[index];
        return house;
    }

    IEnumerator HauntInLoop()
    {
        while (ReadyHauntHouses.Count > 0)
        {
            yield return new WaitForSeconds(Constants.House.GO_HAUNTING_TIME);
            House h = GetRandomHouse(ReadyHauntHouses);
            ((HauntNormalState) h.haunt.CurrentState).GoHaunting();
        }
    }
}
