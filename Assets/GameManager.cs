using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject UIFailed;
    public Text txtScore;
    public Transform heroPosition;

    private static int Score = 0;
    private Vector3 heroStartPosition;

    public static bool isGameOver = false;

    private void Start()
    {
        heroStartPosition = heroPosition.position;
    }
    
    void Update()
    {
        txtScore.text = Score.ToString();

        if (isGameOver)
        {
            Fail();
        }
    }

    public void Fail()
    {
        Time.timeScale = 0f;
        UIFailed.SetActive(true);
    }

    public void PlayAgin()
    {
        UIFailed.SetActive(false);
        Score = 0;
        heroPosition.position = heroStartPosition;
        isGameOver = false;

        Time.timeScale = 1f;
    }

    public static void AddScore(int score)
    {
        Score += score;
    }
}
