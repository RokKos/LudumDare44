using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToNextLevel : MonoBehaviour
{

    public GameObject holder;
    public GameObject stopper;
    public Rigidbody board;
    private float k = 0.005f;
    public int thrust;
    private bool engageStartButton = false;
    private int count=0;
    void OnMouseOver()
{
    if (Input.GetMouseButtonDown(0))
    {
        engageStartButton = true;
        board.AddForce(transform.forward * thrust);
        stopper.transform.gameObject.SetActive(false);
    }
}
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(engageStartButton){
            Vector3 holderPos = holder.transform.position;
            if(count>=10 && count<=30){
                holderPos.y-=0.05f;
            }
            else if(count>30){
                
                holderPos.y+=k;
            }
            k+=0.001f;
            count++;
            holder.transform.position = holderPos;
            if(count==175){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }   
    }
}