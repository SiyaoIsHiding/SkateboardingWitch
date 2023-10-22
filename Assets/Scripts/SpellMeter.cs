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

    public void AdjustSpellMeter(int count)
    {
        float sliderValue = count / (float)Constants.Level.CANDY_MAX;
        slider.value = sliderValue;
        if (count == 0)
        {
            BorderImage.sprite = borders[0];
            spellReady.SetActive(false);
        }
        else if (count == 1)
        {
            BorderImage.sprite = borders[1];
            spellReady.SetActive(false);
        }
        else if (count == 2)
        {
            BorderImage.sprite = borders[2];
            spellReady.SetActive(false);
        }
        else if (count == 3 || count == 4)
        {
            BorderImage.sprite = borders[3];
            spellReady.SetActive(false);
        }
        else
        {
            // 5
            BorderImage.sprite = borders[4];
            spellReady.SetActive(true);
        }
    }
    
}