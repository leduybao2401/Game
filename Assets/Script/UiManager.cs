using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public Canvas gameCanvas;
	private void Awake()
	{
        gameCanvas = FindObjectOfType<Canvas>();
        
	}
	private void OnEnable()
	{
		CharacterEvents.characterDameged +=(CharacterTookDamage);
		CharacterEvents.characterHealed +=(CharacterHealed);
	}
	private void OnDisable()
	{
		CharacterEvents.characterDameged -=(CharacterTookDamage);
		CharacterEvents.characterHealed -=(CharacterHealed);
	}
	public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        //create text at character hit 
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = damageReceived.ToString();

    }
    public void CharacterHealed(GameObject character, int healthRestored)
    {
		// took
		Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
		TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
		tmpText.text = healthRestored.ToString();
	}
}
