using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SpellMeter : MonoBehaviour
{
    public Slider slider;
    public Image BorderImage;
    public Sprite[] borders; // [0] for not full [1] for full
    public GameObject spellReady;

    public void AdjustSpellMeter(float value)
    {
        if (value > 1) value = 1;
        slider.value = value;
        if (value >= 0.99f)
        {
            BorderImage.sprite = borders[1];
            spellReady.SetActive(true);
        }
        else
        {
            BorderImage.sprite = borders[0];
            spellReady.SetActive(false);
        }
    }

    public float GetSpellMeter()
    {
        return slider.value;
    }
}