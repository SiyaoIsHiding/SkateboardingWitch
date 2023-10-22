using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    // [Space, O, P, L, K]
    public Sprite[] buttons;

    public void Awake()
    {
        current = this;
    }
}