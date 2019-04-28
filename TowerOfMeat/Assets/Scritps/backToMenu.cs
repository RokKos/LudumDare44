using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToMenu : MonoBehaviour
{

    public GameObject holder;
    private bool rollingCredits = false;
    private int count = 0;

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            if(rollingCredits==false){
                rollingCredits = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rollingCredits){
            Vector3 holderPos = holder.transform.position;
            if(count<155){
                holderPos.y+=0.1f;
                count++;
            }
            if(count==155){
                count=0;
                rollingCredits=false;
            }
            holder.transform.position = holderPos;
        }
    }
}
