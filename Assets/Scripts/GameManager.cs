using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool Win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    void Start()
    {
       if(gameManager == null)
        {

            gameManager = this;
        }
       if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        InvokeRepeating("Stopper", 0, 1);
    }

    
    void Update()
    {
        PauseCheck();
    }

    private void PauseCheck()
    {
       if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time:{timeToEnd} s");
        if(timeToEnd <=0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if(endGame)
        {
            EndGame();
        }

    }
    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f; // szybkosc czasu gry // np. 0,5f spowalnia gre dwukrotnie , 1f normalnie
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f; // szybkosc czasu gry // np. 0,5f spowalnia gre dwukrotnie , 1f normalnie
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if(Win)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }

    }
    public void AddPoints(int points)
    {
        this.points += points; // trzeba u¿yæ "this" poniewa¿ istnieje zmienna publiczna points i parametr metody points.

    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime , 1);// (na jak¹ metodê sie odwo³aæ,za ile czasu, co ile powtarzaæ)
    }
}
