using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelDone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject holder;
    private int count = 0;
    private bool showEnd = false;
    private float k = 0.2f;

    public void showEndLevel(bool success = true){
        showEnd = true;
    }

    void Start()
    {
		showEnd = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (showEnd == false){
            showEndLevel();
        }
        if(showEnd){
            Vector3 holderPos = holder.transform.position;
            if(count<130){
                holderPos.y-=k;
            }
            k-=0.0015f;
            count++;
            holder.transform.position = holderPos;
            //if(count==175){
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //} 
        }
    }
}
