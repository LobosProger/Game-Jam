using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics instance;
    public float gameTime = 60f;

    Timer gameTimer;
    int lives = 3;

    void Awake()
    {
        if (instance != null)
            Debug.Log("GameMechanics have second example");
        instance = this;
        gameTimer = new Timer(gameTime, GameOver);
    }

    public void Update()
    {
        gameTimer.Update();
    }

    public void LiveDecrease()
    {
        lives--;
        if (lives <= 0)
            GameOver();
    }

    public void IncorrectFitEffect()
    {

    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}


public class Timer
{
    public float timeRemaining;
    GameAction action;

    public Timer(float time, Action action)
    {
        timeRemaining = time;
        this.action = new GameAction(action);
    }

    public void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
            action.Invoke();
    }
}