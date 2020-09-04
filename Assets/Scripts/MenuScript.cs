using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	//GameObject panel;

	// Use this for initialization
	public void hoverOver()
	{
		Button button = GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.colorMultiplier = 1.39f;
		button.colors = cb;
	}

	public void hoverOff()
	{
		Button button = GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.colorMultiplier = 1f;
		button.colors = cb;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
