using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }
	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void Lv1()
	{
		SceneManager.LoadSceneAsync(1);

	}
	public void Lv2()
	{
		SceneManager.LoadSceneAsync(2);

	}
}
