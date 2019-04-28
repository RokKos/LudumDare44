using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoard : MonoBehaviour
{
    public float thrust;
    public Rigidbody board;
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
        }
    }
}
