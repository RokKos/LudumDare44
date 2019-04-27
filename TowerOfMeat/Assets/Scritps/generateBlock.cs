using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlock : MonoBehaviour
{
    public List<MeatPartController> allBlocks;

    private MeatPartController next;

    //public GameObject[] blockArray;
    // Start is called before the first frame update
    void Start()
    {
        next =  Instantiate(allBlocks[Random.Range(0, allBlocks.Count)]);
        next.transform.position = new Vector3(6.6f, 5.8f, 0);
        next.EnableGravity(false);
        
    }

    public MeatPartController GetBlock(){
        MeatPartController ret =  next;
        next = Instantiate(allBlocks[Random.Range(0, allBlocks.Count)]);
        next.transform.position = new Vector3(6.6f, 5.8f, 0);
		next.EnableGravity(false);
        return ret;
	}
    
}
