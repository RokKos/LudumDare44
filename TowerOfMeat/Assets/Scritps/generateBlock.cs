using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlock : MonoBehaviour
{
    public List<MeatPartController> allBlocks;
    //public GameObject[] blockArray;
    // Start is called before the first frame update
    void Start()
    {
        allBlocks = GameObject.FindGameObjectsWithTag("allBlocks");
        Debug.Log(GameObject.FindGameObjectsWithTag("allBlocks").Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)){
            var randomBlock = Random.Range(0, allBlocks.Length);
            Instantiate(allBlocks[randomBlock], new Vector3(0,5,0), Quaternion.identity);
            Debug.Log(randomBlock);
            //run through all blocks, just a test
            for(int i=0;i<allBlocks.Length; i++){
                
                //Debug.Log(allBlocks[i]);
            }
        }
    }

    public MeatPartController GetBlock(){
		return Instantiate(allBlocks[0]);
	}
}
