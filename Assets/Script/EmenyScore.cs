using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyScore : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    private int _killScore;
    private ScoreController _scoreController;

	private void Awake()
	{
		_scoreController = FindObjectOfType<ScoreController>();


	}
	public void AllocateScore()
	{
		_scoreController.AddScore(_killScore);
	}
}
