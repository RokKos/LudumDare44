using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject board;
    // Start is called before the first frame update
    public void nextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void toMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void playGame(){
        Vector3 boardPos = board.transform.position;
        for(var i=0; i<100; i++){
            boardPos.y += 1;
            board.transform.position = boardPos;
        }
        for(var i=0;i<1000;i++){
            Debug.Log(i);
            boardPos.y -= 1;
            board.transform.position = boardPos;
        }
    }
}
