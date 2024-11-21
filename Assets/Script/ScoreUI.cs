using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    private TMP_Text _scoreText;
	

	private void Awake()
	{
		_scoreText = GetComponent<TMP_Text>();
		//_scoreText = transform.Find("Score").GetComponent<TMP_Text>(); // Tìm đối tượng con "ScoreText"
		//_hightScoreText = GetComponent<TMP_Text>(); // Tìm đối tượng con "HightScoreText"

	}

	public void UpdateScore(ScoreController scoreController)
	{
		_scoreText.text = $"Score: {scoreController.Score}";
		// Cập nhật điểm cao nhất
		
	}
}
