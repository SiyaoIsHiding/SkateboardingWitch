using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public Slider healthBar;
    public int candyCount = 0;
    public float timeRemain = 60f;
    public House selectedHouse;

    private void Awake()
    {
        current = this;
        selectedHouse = null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemain -= Time.deltaTime;
    }
    
    public void CandyCollected()
    {
        candyCount++;
        healthBar.value += 0.5f;
    }
}
