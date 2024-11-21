using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChange;

    public int Score { get; private set; }

	

	public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChange.Invoke();

		
	}
	//public void HighScoreUpdate()
	//{
	//	if (PlayerPrefs.HasKey("SaveHightScore"))
	//	{
	//		if(Score > PlayerPrefs.GetInt("SaveHightScore"))
	//		{
	//			PlayerPrefs.SetInt("SaveHightScore", Score);
	//		}
	//	}
	//	else
	//	{
	//		PlayerPrefs.SetInt("SaveHightScore", Score);
	//	}
		
	//}
}
