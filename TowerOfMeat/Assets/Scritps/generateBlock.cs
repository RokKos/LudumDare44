using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlock : MonoBehaviour
{
	[SerializeField] ScreamAudioController screamAudioController;

	[SerializeField] List<MeatPartController> normalBlocks;
	[SerializeField] List<MeatPartController> humanBlocks;

	private List<bool> selectedHumanBlocks;

	private MeatPartController next;
	private bool lastSuccess = true;
	private int maxHumanParts = 0;
	private int maxNormalParts = 0;


	delegate void PlayerLost ();
	PlayerLost playerLost;

	void Start()
    {
		next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
		maxNormalParts--;
		PrepareNextMeatPart();
		lastSuccess = true;
	}

	public void Setup (int humanParts, int normalParts, GameController gameController) {
		selectedHumanBlocks = new List<bool>();
		for (int i = 0; i < humanParts; ++i) {
			selectedHumanBlocks.Add(false);
		}
		maxHumanParts = humanParts;
		maxNormalParts = normalParts;
		playerLost += gameController.PlayerLost;

	}

    public MeatPartController GetBlock(){
        MeatPartController ret =  next;
		if (lastSuccess) {
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
			maxNormalParts--;
		} else {
			next = SelectHumanBodyPart();
			screamAudioController.PlayScream();
		}

		PrepareNextMeatPart();

		if (maxHumanParts < 0 || maxNormalParts < 0) {

		}
		ret.GetRigidbody().isKinematic = false;
		return ret;
	}

	public void SetLastSuccess (bool success) {
		
		if (lastSuccess != success && success) {
			Destroy(next.gameObject);
			maxHumanParts++;
			next = Instantiate(normalBlocks[Random.Range(0, normalBlocks.Count)]);
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
		next.transform.position = new Vector3(3.26f, 4.25f, 0);
		next.GetRigidbody().isKinematic = true;
		//next.EnableGravity(false);
	}

	private MeatPartController SelectHumanBodyPart () {
		int ind = 0;
		do {
			ind = Random.Range(0, humanBlocks.Count);

		} while (selectedHumanBlocks[ind]);

		selectedHumanBlocks[ind] = true;
		maxHumanParts--;
		return Instantiate(humanBlocks[ind]);

	}
    
}
