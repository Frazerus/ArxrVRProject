using System;
using System.Collections;
using System.Collections.Generic;
using PickUps;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;


    private void Awake()
    {
        current = this;
    }
    public event Action<GameObject> OnPickUp;
    
    public void PickUp(GameObject item)
    {
        if (OnPickUp != null)
        {
            OnPickUp(item);
        }
    }

    public event Action<PickUpEnum> OnTryDropItem;

    public void TryDropItem(PickUpEnum item)
    {
        if(OnTryDropItem != null)
        {
            OnTryDropItem(item);
        }
    }

    public event Action<int> OnDropItem;

    public void DropItem(int value)
    {
        if (OnDropItem != null)
        {
            OnDropItem(value);
        }
    }

    public event Action OnStartGame;

    public void StartGame()
    {
        if(OnStartGame != null)
        {
            OnStartGame();
        }
    }

    public event Action OnStopGame;
    private void StopGame()
    {
        if (OnStopGame != null)
        {
            OnStopGame();
        }
    }
    
    public event Action OnPauseGame;
    public void PauseGame()
    {
        if (OnPauseGame != null)
        {
            OnPauseGame();
        }
    }
    
    public event Action OnContinueGame;
    public void ContinueGame()
    {
        if (OnContinueGame != null)
        {
            OnContinueGame();
        }
    }
}
