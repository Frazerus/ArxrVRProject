using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public void StartGame()
    {
        print("starting");
        GameEventSystem.current.StartGame();
    }

    public void ContinueGame()
    {
        print("continue");
        GameEventSystem.current.ContinueGame();
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }

}
