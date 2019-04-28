using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] List<LevelParameters> levels;
	[SerializeField] generateBlock generateBlock;

	private int currLevel = 0;
	void Start()
    {
		currLevel = 0;
		generateBlock.Setup(GetLives(), GetHumanPartsNum(), this);

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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
