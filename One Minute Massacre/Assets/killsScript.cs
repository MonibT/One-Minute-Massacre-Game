using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killsScript : MonoBehaviour
{
    public Text killText;
    public int killCount = 0;

    void Start()
    {
        UpdateKillText();
    }

    public void IncrementKillCount(int points)
    {
        killCount += points;
        UpdateKillText();
    }

    void UpdateKillText()
    {
        killText.text = "POINTS: " + killCount;
    }
}