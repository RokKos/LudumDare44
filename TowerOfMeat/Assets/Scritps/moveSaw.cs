using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSaw : MonoBehaviour
{
    public GameObject saw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sawPos = saw.transform.position;
        if(sawPos.x>-10){
            sawPos.x -= 0.05f;
            saw.transform.position = sawPos;
        }
    }
}
