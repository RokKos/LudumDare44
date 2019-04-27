﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartsManager : MonoBehaviour
{

	[SerializeField] generateBlock GenerateBlock;
	private List<MeatPartController> meatPartsInScene = new List<MeatPartController>();

	delegate void MeatSucces (bool success);
	MeatSucces meatSucces;

	private void Start () {
		meatSucces += GenerateBlock.SetLastSuccess;
	}

	public bool AddMeatPart (MeatPartController meatPart) {
		if (meatPartsInScene.Count == 0) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		}


		MeatPartController topMeatPart = meatPartsInScene[meatPartsInScene.Count - 1];
		bool isOnTop = topMeatPart.GetTopPointOfMeat() < meatPart.GetTopPointOfMeat();
		if (isOnTop) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		} else {
			Destroy(meatPart.gameObject);
			meatSucces(false);
			return false;
		}
		
	}
}
