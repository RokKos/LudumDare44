using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] Text meatLeftText;

	private const string meatText = "MEAT LEFT: ";

	public void UpdateMeatLeftText (int numMeat) {
		meatLeftText.text = meatText + numMeat;
	}
}
