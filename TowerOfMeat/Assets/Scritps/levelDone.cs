using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelDone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject holder;
    public GameObject lvlFailed;
    public GameObject retry;
    public GameObject lvlDone;
    public GameObject nextLvl;
    private int count = 0;
    private bool showEnd = false;
    private float k = 0.2f;

    public void showEndLevel(bool success){
        showEnd = true;
        if(success){
            lvlFailed.transform.gameObject.SetActive(false);
            retry.transform.gameObject.SetActive(false);

            lvlDone.transform.gameObject.SetActive(true);
            nextLvl.transform.gameObject.SetActive(true);
        }
        else{
            lvlFailed.transform.gameObject.SetActive(true);
            retry.transform.gameObject.SetActive(true);

            lvlDone.transform.gameObject.SetActive(false);
            nextLvl.transform.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Testing purposes
        if (Input.GetMouseButtonDown(0) && showEnd == false){
            showEndLevel(true);
        }
        if(Input.GetMouseButtonDown(1) && showEnd == false){
            showEndLevel(false);
        }
        */
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
