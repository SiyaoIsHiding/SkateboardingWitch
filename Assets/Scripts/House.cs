using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    #region debug only
    public string StateName;
    #endregion
    public int HouseId;
    public HouseBaseState HouseState;
    public ShowArea showArea;
    public Candy candy;
    public Bubble bubble;
    public InputManager.ComboRequest RequestedCombo;
    public Haunt haunt;
    
    void Awake()
    {
        HouseState = new HouseNormalState(gameObject);
        RequestedCombo = null;
    }
    
    void Start()
    {
        showArea.OnPlayerEnter += OnPlayerEnter;
        showArea.OnPlayerExit += OnPlayerExit;
    }
    
    void Update()
    {
        StateName = HouseState.StateName.ToString();
        HouseState = HouseState.Process();
    }

    private void OnPlayerEnter(Collider2D collider)
    {
        LevelManager.current.selectedHouse = this;
    }
    
    private void OnPlayerExit(Collider2D collider)
    {
        LevelManager.current.selectedHouse = null;
    }
}
