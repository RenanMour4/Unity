using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{  
    private bool NextLevel;
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        NextLevel = true;
        
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.ShowGameWin();
        }
    }

    public void NextGame(string levelName)
    {
        if(NextLevel == true)
        {
        SceneManager.LoadScene(levelName);
        }
    }


    


}
