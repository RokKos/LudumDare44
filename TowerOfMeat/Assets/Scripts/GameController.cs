using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] List<LevelParameters> levels;

	private int currLevel = 0;
	void Start()
    {
		currLevel = 0;

	}

	public float GetRateOfDroping () {
		return levels[currLevel].RateOfDroping;
	}


}
