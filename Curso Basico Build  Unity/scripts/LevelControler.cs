using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelControler : MonoBehaviour
{

    public static LevelControler instance;
    public int totalPickups;

    public string scene;

    public Text totalText;
    
    public Text currentText;

    public GameObject levelText;

    private void Awake()
    {
        instance = this;
    }


    private int currentPickups;
    // Start is called before the first frame update
    void Start()
    {
        totalText.text ="Total: " + totalPickups;
    }

    public void setPickups()
    {
        currentPickups ++;

        currentText.text = "Coletados: " + currentPickups;

        Debug.Log(currentPickups);

        if(currentPickups >= totalPickups){
            levelText.SetActive(true);
            Invoke("LoadNextScene",2f);
        }
    }

    void LoadNextScene()
    {
        SceneController.instance.LoadScene(scene);
    }
}
