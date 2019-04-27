﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlock : MonoBehaviour
{
    [SerializeField] List<MeatPartController> normalBlocks;
	[SerializeField] List<MeatPartController> humanBlocks;

	private MeatPartController next;
	private bool lastSuccess = true;


	void Start()
    {
		next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
		PrepareNextMeatPart();
		lastSuccess = true;


	}

    public MeatPartController GetBlock(){
        MeatPartController ret =  next;
		if (lastSuccess) {
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
		} else {
			next = Instantiate(humanBlocks[Random.Range(0, humanBlocks.Count)]);
		}

		PrepareNextMeatPart();
		return ret;
	}

	public void SetLastSuccess (bool success) {
		
		if (lastSuccess != success && success) {
			Destroy(next.gameObject);
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
		} else if (lastSuccess != success && !success) {
			Destroy(next.gameObject);
			next = Instantiate(humanBlocks[Random.Range(0, humanBlocks.Count)]);
		}
		lastSuccess = success;
		PrepareNextMeatPart();
	}

	public void PrepareNextMeatPart () {
		next.transform.position = new Vector3(6.2f, 7.3f, 0);
		next.EnableGravity(false);
	}
    
}
