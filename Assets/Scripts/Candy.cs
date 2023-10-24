using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: candy does not appear again after collected
        LevelManager.current.CandyCollected();
        // delay 0.3 seconds
        StartCoroutine(Delay());
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
    
}
