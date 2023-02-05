using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	#region Setuping
	private const string LevelForLoadingPlayerPrefs = "Level";
	[SerializeField] private Text textToShoowingCurrentLevel;
	#endregion

	private static bool isInitializedGame;
	public static int currentLevel;

	private void Start()
	{
		if (!isInitializedGame)
		{
			isInitializedGame = true;
			currentLevel = PlayerPrefs.GetInt(LevelForLoadingPlayerPrefs, 1);
		}

		textToShoowingCurrentLevel.text = "Level " + currentLevel.ToString();
	}

	public static void LoadNextLevel()
	{
		//currentLevel++;
		//PlayerPrefs.SetInt(LevelForLoadingPlayerPrefs, currentLevel);
	}

	public static void LoadCurrentLevel() => SceneManager.LoadScene(currentLevel.ToString());
}
