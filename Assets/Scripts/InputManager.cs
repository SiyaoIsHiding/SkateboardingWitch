using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Animator Anim; 
    private void Awake()
    {
        PresetCombo.InitPresetCombo();
    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #region tricks

        public class SingleKey
        {
            public enum KeyType
            {
                SPACE,
                O,
                K,
                L,
                P
            }
            
            public KeyType keyType;
            public SingleKey(KeyType keyType)
            {
                this.keyType = keyType;
            }
        }

        public class PresetCombo
        {
            public enum ComboType
            {
                TRICKCOMBO1,
                TRICKCOMBO2,
                TRICKCOMBO3,
                TRICKCOMBO4,
                TRICKCOMBO5,
                TRICKCOMBO6,
            }

            public List<SingleKey> KeySequence;
            public ComboType Type;
            public static List<PresetCombo> PresetCombos;
            public PresetCombo(ComboType comboType, List<SingleKey> keySequence)
            {
                KeySequence = keySequence;
                Type = comboType;
            }
            
            public static void InitPresetCombo()
            {
                PresetCombos = new List<PresetCombo>();
                // each combo is space + three other keys
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO1, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.O), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.L)}));
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO2, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.O), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.P)}));
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO3, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.O), new SingleKey(SingleKey.KeyType.L), new SingleKey(SingleKey.KeyType.P)}));
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO4, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.L), new SingleKey(SingleKey.KeyType.P)}));
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO5, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.L)}));
                PresetCombos.Add(new PresetCombo(ComboType.TRICKCOMBO6, new List<SingleKey>(){new SingleKey(SingleKey.KeyType.SPACE), new SingleKey(SingleKey.KeyType.L), new SingleKey(SingleKey.KeyType.K), new SingleKey(SingleKey.KeyType.L)}));
            }
        }

        public class ComboRequest
        {
            public PresetCombo Combo;
            public int ProgressIndex;
            public ComboRequest(PresetCombo combo)
            {
                Combo = combo;
                ProgressIndex = 0;
            }
            
            public event Action<Null> OnTrickComplete;
            public event Action<Null> OnTrickFailed;
            public bool Progress(SingleKey.KeyType key)
            {
                if (key == Combo.KeySequence[ProgressIndex].keyType)
                {
                    if (ProgressIndex < Combo.KeySequence.Count -1 )
                    {
                        ProgressIndex++;
                        Debug.Log(key.ToString()+" index: "+ ProgressIndex);
                        return true;
                    }
                    else
                    {
                        Debug.Log(key.ToString()+" finished");
                        OnTrickComplete?.Invoke(null);
                        return true;
                    }
                }
                else
                {
                    ProgressIndex = 0;
                    OnTrickFailed?.Invoke(null);
                    return false;
                }
            }

            public void ProgressUnintendedIdle()
            {
                ProgressIndex = 0;
                OnTrickFailed?.Invoke(null);
            }
        }
    #endregion
}