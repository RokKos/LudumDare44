using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeg : MonoBehaviour
{
    public GameObject leg;
    private int vectorX = -1;
    private int vectorY = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 legPos = leg.transform.position;
        if(legPos.x<-6.8 || legPos.x>6.7){
            vectorX = -vectorX;
        }
        if(legPos.y<-4 || legPos.y>6){
            vectorY = -vectorY;
        }
        legPos.x+=0.05f*vectorX;
        legPos.y+=0.05f*vectorY;
        leg.transform.Rotate(1,1,1, Space.Self);
        leg.transform.position = legPos;
        //Debug.Log(leg.transform.position);   
    }
}
