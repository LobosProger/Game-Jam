using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
	public static CanvasManager singleton;

	private Animator animatorPanelForHideAndShow;

	private void Awake()
	{
		animatorPanelForHideAndShow = GetComponent<Animator>();
		singleton = this;
	}

	public void ShowGameplay()
	{
		animatorPanelForHideAndShow.SetTrigger("Show");
	}

	public void HideGameplay()
	{
		animatorPanelForHideAndShow.SetTrigger("Hide");
	}
}
