using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	#region Setuping
	private const string LevelForLoadingPlayerPrefs = "Level";
	private const int maxAmountOfLevels = 3;
	//[SerializeField] private Text textToShoowingCurrentLevel;
	#endregion

	//private static bool isInitializedGame;
	private static int currentLevelForSwitching;
	private static int currentLevel => (currentLevelForSwitching % 3) + 1;


	/*private void Start()
	{
		if (!isInitializedGame)
		{
			isInitializedGame = true;
			currentLevel = PlayerPrefs.GetInt(LevelForLoadingPlayerPrefs, 1);
		}

		textToShoowingCurrentLevel.text = "Level " + currentLevel.ToString();
	}*/

	public static void SwitchNextLevel() => currentLevelForSwitching++;

	public static int GetCurrentLevel() => currentLevel;

	public static void LoadCurrentLevel() => SceneManager.LoadScene(currentLevel.ToString());
}
