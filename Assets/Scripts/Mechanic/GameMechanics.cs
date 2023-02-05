using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameMechanics : MonoBehaviour
{
	public static GameMechanics instance;
	public float gameTime = 60f;
	public Text timerText;

	Timer gameTimer;
	int lives = 3;
	int unsolvedKeyHolesAmount;

	void Awake()
	{
		if (instance != null)
			Debug.Log("GameMechanics have second example");
		instance = this;
		gameTimer = new Timer(gameTime, GameOver);

		//DontDestroyOnLoad(this.gameObject);
	}

	public void Update()
	{
		gameTimer.Update();
		timerText.text = gameTimer.ToString();
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

	public void AddKeyHole() => unsolvedKeyHolesAmount++;

	public void SolveHole()
	{
		unsolvedKeyHolesAmount--;
		if (unsolvedKeyHolesAmount <= 0)
			Win();
	}

	void Win()
	{
		Debug.Log("Win");
		gameTimer.Stop();
	}

	void GameOver()
	{
		Debug.Log("GameOver");
	}
}


public class Timer
{
	public float timeRemaining;
	bool isRunning = true;
	GameAction action;

	public Timer(float time, Action action)
	{
		timeRemaining = time;
		this.action = new GameAction(action);
		this.action += delegate () { isRunning = false; };
	}

	public void Update()
	{
		if (isRunning)
		{
			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0)
				action.Invoke();
		}
	}

	public void Stop()
	{
		isRunning = false;
	}

	public override string ToString()
	{
		int minutes = (int)(timeRemaining / 60);
		int seconds = (int)(timeRemaining % 60);
		return minutes.ToString() + ":" + (seconds >= 10 ? seconds.ToString() : ("0" + seconds.ToString()));
	}
}