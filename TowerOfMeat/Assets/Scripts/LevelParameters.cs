using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "LevelParameters", menuName = "TowerOfMeat/LevelParameters", order = 1)]
public class LevelParameters : ScriptableObject {
	public float SpeedOfSaw = 2.0f;
	public int NumberOfElement = 20;
	public int Lifes = 5;
	public float RateOfDroping = 0.5f;
	public float LineHeight = 5.38f;
}