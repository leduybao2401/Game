using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    Damgeable playerDamageable;
	// Start is called before the first frame update
	private void Awake()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player == null)
		{
			Debug.Log("No player found in the scene . Make sure it has tag 'Player'");
		}
		playerDamageable = player.GetComponent<Damgeable>();
	}
	void Start()
    {
       //GameObject player =  GameObject.FindGameObjectWithTag("Player");
       // playerDamageable = player.GetComponent<Damgeable>();
        healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarText.text = "HP " + playerDamageable.Health + "/" + playerDamageable.MaxHealth;
    }
	private void OnEnable()
	{
		playerDamageable.healthChange.AddListener(OnPlayHealthChange);
	}
	private void OnDisable()
	{
		playerDamageable.healthChange.RemoveListener(OnPlayHealthChange);
	}

	private float CalculateSliderPercentage(float currentHealth, float maxHealth)
	{
        return currentHealth / maxHealth;
	}
	private void OnPlayHealthChange(int newHealth, int maxHealth)
	{
		healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
		healthBarText.text = "HP " + newHealth + "/" + maxHealth;
	}
	// Update is called once per frame
	void Update()
    {
		
	}
}
