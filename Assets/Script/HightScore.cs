using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HightScore : MonoBehaviour
{


	
	private TMP_Text _hightScoreText;

	private void Awake()
	{
		
		//_scoreText = transform.Find("Score").GetComponent<TMP_Text>(); // Tìm đối tượng con "ScoreText"
		//_hightScoreText = GetComponent<TMP_Text>(); // Tìm đối tượng con "HightScoreText"

	}

	public void UpdateScore(ScoreController scoreController)
	{
		
		// Cập nhật điểm cao nhất
		_hightScoreText.text = PlayerPrefs.GetInt("SaveHightScore").ToString();
		//_hightScoreText.text = $"High Score: {scoreController.HightScore}";
	}
}
