using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartsManager : MonoBehaviour
{
	private List<MeatPartController> meatPartsInScene = new List<MeatPartController>();

	public void AddMeatPart (MeatPartController meatPart) {
		if (meatPartsInScene.Count == 0) {
			meatPartsInScene.Add(meatPart);
			return;
		}


		MeatPartController topMeatPart = meatPartsInScene[meatPartsInScene.Count - 1];
		bool isOnTop = topMeatPart.GetTopPointOfMeat() < meatPart.GetTopPointOfMeat();
		if (isOnTop) {
			meatPartsInScene.Add(meatPart);
		} else {
			Destroy(meatPart.gameObject);
		}
		
	}
}
