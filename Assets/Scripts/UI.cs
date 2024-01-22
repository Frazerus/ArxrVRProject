using System.Collections;
using System.Collections.Generic;
using GoogleVR.VideoDemo;
using UnityEngine;
using UnityEngine.Timeline;

public class UI : MonoBehaviour
{
    public GameObject pauseCanvas;
    private GameObject[] StartUiElements;
    private GameObject[] StopUIElements;
    private GameObject[] PauseUIElements;

    private void Awake()
    {
        StartUiElements = GameObject.FindGameObjectsWithTag("StartUI");
        StopUIElements = GameObject.FindGameObjectsWithTag("StopUI");
        PauseUIElements = GameObject.FindGameObjectsWithTag("PauseUI");
        ShowHideUI(StopUIElements, false);
    }


    void Start()
    {
        GameEventSystem.current.OnStartGame += HideStartUI;
        GameEventSystem.current.OnStopGame += ShowStopUI;
        GameEventSystem.current.OnPauseGame += ShowPauseUI;
        GameEventSystem.current.OnContinueGame += HidePauseUI;
    }


    private void HideStartUI()
    {
        ShowHideUI(StartUiElements, false);
    }

    private void ShowStopUI()
    {
        ShowHideUI(StopUIElements, true);
    }

    private void ShowHideUI(GameObject[] toHide, bool show)
    {
        foreach (var ui in toHide)
        {
            ui.SetActive(show);
        }
    }

    private void ShowPauseUI()
    {
        var playerPosition = GameObject.Find("Player").transform.position;
        pauseCanvas.GetComponent<RectTransform>().anchoredPosition3D = playerPosition;
        pauseCanvas.SetActive(true);
    }

    private void HidePauseUI()
    {
        pauseCanvas.SetActive(false);
    }
}