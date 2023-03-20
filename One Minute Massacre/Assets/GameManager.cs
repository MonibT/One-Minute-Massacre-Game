using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float moveSpeed;
    public float currentScore;
    public float totalPoints = 0;
    public int maxHealth;
    public int Bulletdamage;
    public Text TpointsText;

    private void Start()
    {
        TotalpointsText();
    }
    private void Update()
    {
               // Update moveSpeed value based on PlayerMovement moveSpeed value
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            moveSpeed = playerMovement.moveSpeed;
        }
        if (player != null)
        {
            PlayerLife playerLife = player.GetComponent<PlayerLife>();
            maxHealth = playerLife.maxHealth;
        }

        // Update bulletDamage value based on Bullet bulletDamage value
        GameObject bullet = GameObject.FindWithTag("Bullet");
        if (bullet != null)
        {
            bullet bulletScript = bullet.GetComponent<bullet>();
            Bulletdamage = bulletScript.Bulletdamage;
        }
        GameObject Timer = GameObject.FindWithTag("timer");
        if (Timer != null)
        {
            Timer timer = Timer.GetComponent<Timer>();


        }

        GameObject Score = GameObject.FindWithTag("Score");
        if (Score != null)
        {
            killsScript killsscript = Score.GetComponent<killsScript>();
            currentScore = killsscript.killCount;
            TotalpointsText();
        }
        
    }


    public void TotalpointsText()
    {
        totalPoints += currentScore;
        //TpointsText.text = "TOTAL POINTS: " + totalPoints;
    }

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

