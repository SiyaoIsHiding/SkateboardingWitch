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
        public List<SingleKey.KeyType> KeySequence;
        public static List<PresetCombo> PresetCombos;

        public PresetCombo(List<SingleKey.KeyType> keySequence)
        {
            KeySequence = keySequence;
        }

        public static void InitPresetCombo()
        {
            PresetCombos = new List<PresetCombo>();
            // each combo is space + three other keys
            SingleKey.KeyType[] type4 =
                { SingleKey.KeyType.P, SingleKey.KeyType.O, SingleKey.KeyType.K, SingleKey.KeyType.L };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        PresetCombos.Add(new PresetCombo(new List<SingleKey.KeyType>()
                        {
                            SingleKey.KeyType.SPACE, type4[i], type4[j], type4[k]
                        }));
                    }
                }
            }
        }
    }

    public class ComboRequest
    {
        public PresetCombo Combo;
        private bool _finished = false;
        public int ProgressIndex;

        public ComboRequest(PresetCombo combo)
        {
            Combo = combo;
            ProgressIndex = 0;
            OnTrickComplete += (@null => {GameManager.current.trickhit.Play();});
            OnTrickComplete += (@null =>
            {
                cheer();
            });
            OnTrickFailed += (@null => {GameManager.current.resident_boo.Play();});
        }

        IEnumerator cheer()
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.current.resident_cheer.Play();
        }

        public event Action<Null> OnTrickComplete;
        public event Action<Null> OnTrickFailed;

        public bool Progress(SingleKey.KeyType key)
        {
            if (LevelManager.current.selectedHouse && LevelManager.current.selectedHouse.RequestedCombo == this
                                                   && key == Combo.KeySequence[ProgressIndex])
            {
                if (ProgressIndex < Combo.KeySequence.Count - 1)
                {
                    ProgressIndex++;
                    return true;
                }
                else
                {
                    _finished = true;
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
        }
    }

    #endregion
}