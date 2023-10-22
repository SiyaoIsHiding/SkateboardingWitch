using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public int candyCount = 0;
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

        StartCoroutine(HauntInLoop());
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void CandyCollected()
    {
        if (candyCount < Constants.Level.CANDY_MAX)
        {
            candyCount++;
        }
        spellMeter.AdjustSpellMeter(candyCount);
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
            Debug.Log(h.HouseId);
            Debug.Log(h.haunt.CurrentState.StateName + " " + h.HouseId + " is haunting");
            ((HauntNormalState) h.haunt.CurrentState).GoHaunting();
        }
    }
}
