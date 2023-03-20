using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float startingTime = 60f;
    public Text countdownText;
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject LevelCompleteUI;
    [SerializeField] public GameObject Player;
    public AudioSource levelcomplete;

    public float _totalPoints;
    public float _currentScore;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            
            Pause();
            currentTime = 0;
        }
        GameObject GM = GameObject.FindWithTag("GM");
        if (GM != null)
        {
            GameManager Gamemanager = GM.GetComponent<GameManager>();
            _totalPoints = Gamemanager.totalPoints;
            _currentScore = Gamemanager.currentScore;
        }
    }
    public void Pause()
    {
        LevelCompleteUI.SetActive(true);
        levelcomplete.Play();
        Player.SetActive(false);
        GameIsPaused = true;
    }
    public void Resume()
    {
        LevelCompleteUI.SetActive(false);
        Player.SetActive(true);
        GameIsPaused = false;
    }
}
