using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	#region Setuping
	private const string LevelForLoadingPlayerPrefs = "Level";
	[SerializeField] private Text textToShoowingCurrentLevel;
	#endregion

	private static bool isInitializedGame;
	private static int currentLevel;

	private void Start()
	{
		if (!isInitializedGame)
		{
			isInitializedGame = true;
			currentLevel = PlayerPrefs.GetInt(LevelForLoadingPlayerPrefs, 1);
		}

		textToShoowingCurrentLevel.text = "Level " + currentLevel.ToString();
	}

	public static void SwitchNextLevel()
	{
		currentLevel++;
		PlayerPrefs.SetInt(LevelForLoadingPlayerPrefs, currentLevel);
	}
}
