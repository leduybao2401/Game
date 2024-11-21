using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 moveSpeed = new Vector3(0,75,0);
    RectTransform textTransForm;
	public float timeToFade = 1f;
	TextMeshProUGUI textMeshPro;
	private float timeElapsed = 0f;
	private Color startColor;
	private void Awake()
	{
		textTransForm = GetComponent<RectTransform>();
		textMeshPro = GetComponent<TextMeshProUGUI>();
		startColor = textMeshPro.color;
	}
	public void Update()
	{
		textTransForm.position += moveSpeed * Time.deltaTime;

		timeElapsed += Time.deltaTime;
		if(timeElapsed < timeToFade)
		{
			float fadeAlpha = startColor.a * (1 - timeElapsed / timeToFade);
			textMeshPro.color = new Color(startColor.r, startColor.g,startColor.b, fadeAlpha);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
