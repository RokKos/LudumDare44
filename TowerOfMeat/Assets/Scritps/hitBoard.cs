using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoard : MonoBehaviour
{
    public float thrust;
    public Rigidbody board;
    public GameObject cube;
    private bool moveBoard = false;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private int count = 0;
    private int countLeft = 0;
    private int countRight = 0;
    // Start is called before the first frame update
    void Start()
    {
        board = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Input.mousePosition;

            board.AddForceAtPosition(Vector3.forward * thrust,  Camera.main.ScreenToViewportPoint(mousePos) );
            //Debug.Log(Camera.main.ScreenToViewportPoint(mousePos)[0]);
            if(Camera.main.ScreenToViewportPoint(mousePos)[0]<0.4){
                //Debug.Log("rotate left");
                //rotatingLeft = true;
                //board.transform.Rotate(0,1,0, Space.Self);
            }
            else if(Camera.main.ScreenToViewportPoint(mousePos)[0]>0.6){
                //Debug.Log("rotate right");
                //rotatingRight = true;
                //board.transform.Rotate(0,-1,0, Space.Self);
            }
            
            
            //moveBoard = true;
        }

        if(rotatingLeft){
            board.transform.Rotate(0,0.15f,0, Space.Self);
            countLeft++;
        }
        else if(rotatingRight){
            board.transform.Rotate(0,-0.15f,0, Space.Self);
            countRight++;
        }

        if(countRight>=25){
            countRight = 0;
            rotatingRight = false;
        }
        if(countLeft>=25){
            rotatingLeft = false;
            countLeft = 0;
        }
        
        if(moveBoard){
            //Debug.Log(moveBoard);
            Vector3 cubePos = cube.transform.position;
            
            if(count>50 && count<100){
                cubePos.y-=0.05f;
            }
            else if(count>=100){cubePos.y+=0.1f;}
            count++;
            cube.transform.position = cubePos;
            if(cubePos.y>30){
                moveBoard=false;
            }
        }
    }
}
