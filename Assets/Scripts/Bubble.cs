using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public SpriteRenderer[] buttons;

    private InputManager.PresetCombo combo; 
    public SpriteRenderer _spriteRenderer;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInvisible()
    {
        _spriteRenderer.enabled = false;
        foreach (var button in buttons)
        {
            button.enabled = false;
        }
    }

    public void SetVisible()
    {
        _spriteRenderer.enabled = true;
        foreach (var button in buttons)
        {
            button.enabled = true;
        }
        ShowButtonsOnBubble();
    }

    public void SetCombo(InputManager.PresetCombo _combo)
    {
        combo = _combo;
    }

    public void ShowButtonsOnBubble()
    {
        for (int i = 0; i < 3; i++)
        {
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