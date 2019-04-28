using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject holder;
    public GameObject lvlFailed;
    public GameObject retry;
    public GameObject lvlDone;
    public GameObject nextLvl;
    private int count = 0;
    private bool showEnd = false;
    private bool moveBoardAndProgress = false;
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
        
        if (Input.GetMouseButtonDown(0) && showEnd == false){
            showEndLevel(true);
        }
        if(Input.GetMouseButtonDown(1) && showEnd == false){
            showEndLevel(false);
        }
        
        if(showEnd){
            Vector3 holderPos = holder.transform.position;
            if(count<130){
                holderPos.y-=k;
                count++;
            }
            k-=0.0015f;
            
            holder.transform.position = holderPos;
            
        }
        //Debug.Log(count);
            if(count==130){
        if(Input.GetKeyDown("space")){
            moveBoardAndProgress=true;
            k=0.1f;}
        }
        if(moveBoardAndProgress){
            Vector3 holderPos = holder.transform.position;
            if(count<265){
                holderPos.y+=k;
                count++;
            }
            k+=0.0015f;
            holder.transform.position = holderPos;
        }
        if(count>=265){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
