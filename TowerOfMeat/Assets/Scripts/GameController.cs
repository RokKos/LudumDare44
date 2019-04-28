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
	[SerializeField] levelDone LevelDone;
	[SerializeField] GameObject gameParent;

	private int currLevel = 0;
	void Start()
    {
		currLevel = 0;
		generateBlock.Setup(GetLives(), GetHumanPartsNum(), this);
		gameParent.SetActive(true);
		LevelDonePatrent.SetActive(false);

	}

	private void Update () {
		if (meatPartsManager.GetMaxMeatHeight() > GetLevelHeight()) {
			currLevel++;
			LevelDonePatrent.SetActive(true);
			LevelDone.showEndLevel(true);
			gameParent.SetActive(false);

			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
		// TODO:
		LevelDonePatrent.SetActive(true);
		LevelDone.showEndLevel(false);
		gameParent.SetActive(false);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	private float GetLevelHeight () {
		return levels[currLevel].LineHeight;
	}
}
