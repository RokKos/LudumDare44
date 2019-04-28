using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] Text meatLeftText;
	[SerializeField] List<GameObject> bodySprites;

	private const string meatText = "MEAT LEFT: ";

	private void Start () {
		foreach (GameObject bodySprite in bodySprites) {
			bodySprite.SetActive(false);
		}

		bodySprites[0].SetActive(true);
	}

	public void UpdateMeatLeftText (int numMeat) {
		meatLeftText.text = meatText + numMeat;
	}

	public void EnableSprite (int ind, bool enable = true) {
		bodySprites[ind + 1].SetActive(enable);
	}
}
