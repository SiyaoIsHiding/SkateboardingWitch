using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public SpriteRenderer[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButtonsOnBubble(InputManager.PresetCombo combo)
    {
        Debug.Log("ShowButtonsOnBubble");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(combo.KeySequence.Count);
            Debug.Log(GameManager.current.buttons.Length);
            Debug.Log(combo.KeySequence[i+1]);
            switch (combo.KeySequence[i+1])
            {
                case InputManager.SingleKey.KeyType.O:
                    buttons[i].sprite = GameManager.current.buttons[1];
                    break;
                case InputManager.SingleKey.KeyType.P:
                    buttons[i].sprite = GameManager.current.buttons[2];
                    break;
                case InputManager.SingleKey.KeyType.L:
                    buttons[i].sprite = GameManager.current.buttons[3];
                    break;
                case InputManager.SingleKey.KeyType.K:
                    buttons[i].sprite = GameManager.current.buttons[4];
                    break;
            }
            
        }
    }
}