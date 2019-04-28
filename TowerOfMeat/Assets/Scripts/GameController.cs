using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] List<LevelParameters> levels;
	[SerializeField] generateBlock generateBlock;
	[SerializeField] MeatPartsManager meatPartsManager;

	private int currLevel = 0;
	void Start()
    {
		currLevel = 0;
		generateBlock.Setup(GetLives(), GetHumanPartsNum(), this);

	}

	private void Update () {
		if (meatPartsManager.GetMaxMeatHeight() > GetLevelHeight()) {
			currLevel++;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	private float GetLevelHeight () {
		return levels[currLevel].LineHeight;
	}
}
