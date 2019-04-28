using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] List<LevelParameters> levels;
	[SerializeField] generateBlock generateBlock;
	[SerializeField] MeatPartsManager meatPartsManager;

	[SerializeField] GameObject LevelDonePatrent;
	[SerializeField] testScript LevelDone;
	[SerializeField] GameObject gameParent;

	private const string kKeyLevel = "LevelNum";
	private int currLevel = 0;

	private bool updatedLevel = false;
	void Start()
    {
		updatedLevel = false;
		currLevel = PlayerPrefs.GetInt(kKeyLevel, 0);
		generateBlock.Setup(GetLives(), GetHumanPartsNum(), this);
		gameParent.SetActive(true);
		LevelDonePatrent.SetActive(false);
	}

	private void Update () {
		if (!updatedLevel && meatPartsManager.GetMaxMeatHeight() > GetLevelHeight()) {

			int levelNum = Mathf.Min(levels.Count - 1, PlayerPrefs.GetInt(kKeyLevel, 0) + 1);
			PlayerPrefs.SetInt(kKeyLevel, levelNum);
			LevelDonePatrent.SetActive(true);
			LevelDone.showEndLevel(true);
			gameParent.SetActive(false);
			updatedLevel = true;
		}
	}

	public float GetRateOfDroping () {
		return levels[currLevel].RateOfDroping;
	}

	public int GetLives () {
		return levels[currLevel].Lifes;
	}

	public int GetHumanPartsNum () {
		return levels[currLevel].NumberOfElement;
	}

	public void PlayerLost () {
		LevelDonePatrent.SetActive(true);
		LevelDone.showEndLevel(false);
		gameParent.SetActive(false);
	}
	public float GetLevelHeight () {
		return levels[currLevel].LineHeight;
	}
}
