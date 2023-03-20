using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu UM;
    //current
    public Text pointsText;
    public Text speedText;
    public Text healthText;
    public Text gunDamage;


    //Cost
    public Text speedCostText;
    public Text healthCostText;
    public Text gunDamageCostText;

    private int speedCost = 50;
    private int healthCost = 100;
    private int gunDamageCost = 150;

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (UM == null)
        {
            UM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdatePointsText();
        UpdateUpgradeCosts();
    }

    void UpdatePointsText()
    {
        pointsText.text = "Points: " + GameManager.instance.currentScore.ToString();
        speedText.text = "SPEED: " + GameManager.instance.moveSpeed.ToString();
        healthText.text = "HEALTH: " + GameManager.instance.maxHealth.ToString();
        gunDamage.text = "GUN DAMAGE: " + GameManager.instance.Bulletdamage.ToString();
    }

    void UpdateUpgradeCosts()
    {
        speedCostText.text = "UPGRADE " + "(" + speedCost.ToString() + ")";
        healthCostText.text = "UPGRADE " + "(" + healthCost.ToString() + ")";
        gunDamageCostText.text = "UPGRADE " + "(" + gunDamageCost.ToString() + ")";
    }

    public void UpgradeSpeed()
    {
        if (GameManager.instance.currentScore >= speedCost)
        {
            GameManager.instance.moveSpeed += 10;
            GameManager.instance.currentScore -= speedCost;
            UpdatePointsText();
            UpdateUpgradeCosts();
        }
        else
        {
            // Display message that user doesn't have enough points
        }
    }
    public void UpgradeHealth()
    {
        if (GameManager.instance.currentScore >= healthCost)
        {
            GameManager.instance.maxHealth += 50;
            GameManager.instance.currentScore -= healthCost;
            UpdatePointsText();
            UpdateUpgradeCosts();
        }
        else
        {
            // Display message that user doesn't have enough points
        }
    }

    public void UpgradeGunDamage()
    {
        if (GameManager.instance.currentScore >= gunDamageCost)
        {
            GameManager.instance.Bulletdamage += 50;
            GameManager.instance.currentScore -= gunDamageCost;
            UpdatePointsText();
            UpdateUpgradeCosts();
        }
        else
        {
            // Display message that user doesn't have enough points
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}