using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stabilizeCredits : MonoBehaviour
{
    public GameObject creditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creditsPanel.transform.rotation.eulerAngles.z!=0){
            Vector3 v = creditsPanel.transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler (v.x, v.y, 0);
        }
    }
}
