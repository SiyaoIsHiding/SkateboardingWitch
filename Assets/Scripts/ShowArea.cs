using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public event Action<Collider2D> OnPlayerEnter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnPlayerEnter?.Invoke(other);
    }

    public event Action<Collider2D> OnPlayerExit;
    private void OnTriggerExit2D(Collider2D other)
    {
        OnPlayerExit?.Invoke(other);
    }
}