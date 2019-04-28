using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlock : MonoBehaviour
{
	[SerializeField] ScreamAudioController screamAudioController;
	[SerializeField] GameController gameController;
	[SerializeField] Transform gameParent;
	[SerializeField] UIController uiController;

	[SerializeField] List<MeatPartController> normalBlocks;
	[SerializeField] List<MeatPartController> humanBlocks;

	private List<bool> selectedHumanBlocks;

	private MeatPartController next;
	private bool lastSuccess = true;
	private int maxHumanParts = 0;
	private int maxNormalParts = 0;
	private int lastSelectedHumanPart = 0;


	delegate void PlayerLost ();
	PlayerLost playerLost;

	void Start()
    {
		next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)], gameParent);
		maxNormalParts--;
		PrepareNextMeatPart();
		lastSuccess = true;
		lastSelectedHumanPart = 0;
	}

	public void Setup (int humanParts, int normalParts, GameController gameController) {
		selectedHumanBlocks = new List<bool>();
		for (int i = 0; i < humanParts; ++i) {
			selectedHumanBlocks.Add(false);
		}
		maxHumanParts = humanParts;
		maxNormalParts = normalParts;
		uiController.UpdateMeatLeftText(maxNormalParts);
		playerLost += gameController.PlayerLost;

	}

    public MeatPartController GetBlock(){
        MeatPartController ret =  next;
		if (lastSuccess) {
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)], gameParent);
			maxNormalParts--;
		} else {
			next = SelectHumanBodyPart();
			screamAudioController.PlayScream();
		}

		PrepareNextMeatPart();

		if (maxHumanParts < 0 || maxNormalParts < 0) {
			gameController.PlayerLost();
		}
		ret.GetRigidbody().isKinematic = false;

		uiController.UpdateMeatLeftText(maxNormalParts);

		return ret;
	}

	public void SetLastSuccess (bool success) {
		
		if (lastSuccess != success && success) {
			Destroy(next.gameObject);
			maxHumanParts++;
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)], gameParent);
			uiController.EnableSprite(lastSelectedHumanPart, false);
			maxNormalParts--;
		} else if (lastSuccess != success && !success) {
			Destroy(next.gameObject);
			maxNormalParts++;
			next = SelectHumanBodyPart();
		}
		lastSuccess = success;
		PrepareNextMeatPart();
	}

	public void PrepareNextMeatPart () {
		//next.transform.localScale = next.GetOriginalScale() / 3.0f;
		next.transform.position = new Vector3(2.281f, 8.313f, 0);
		next.GetRigidbody().isKinematic = true;
		next.GetCollider().enabled = false;
	}

	private MeatPartController SelectHumanBodyPart () {
		if (maxHumanParts <= 0) {
			gameController.PlayerLost();
			return null;
		}

		int ind = 0;
		int maxWhile = 500;
		do {
			ind = Random.Range(0, humanBlocks.Count);
			maxWhile--;
		} while (selectedHumanBlocks[ind] && maxWhile > 0);

		selectedHumanBlocks[ind] = true;
		lastSelectedHumanPart = ind;
		uiController.EnableSprite(ind);
		maxHumanParts--;
		return Instantiate(humanBlocks[ind], gameParent);

	}
    
}
