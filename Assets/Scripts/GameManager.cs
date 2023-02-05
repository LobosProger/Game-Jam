using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public static GameManager singleton;

	//public bool isPlayerOnMainMenu = true;

	private void Awake()
	{
		singleton = this;
		DontDestroyOnLoad(this.gameObject);
	}

	public static void LoadCurrentLevel() => singleton.StartCoroutine(singleton.LoadLevel());

	private IEnumerator LoadLevel()
	{
		CanvasManager.singleton.HideGameplay();
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(LevelManager.currentLevel.ToString());
	}
}
