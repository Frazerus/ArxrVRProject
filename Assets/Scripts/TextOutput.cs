using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        GameEventSystem.current.OnPauseGame += ChangeToCurrentText;
    }

    private void ChangeToCurrentText()
    {
        text.text = $"Score\n{PlayerStats.CurrentScore.ToString()}";
    }
}
