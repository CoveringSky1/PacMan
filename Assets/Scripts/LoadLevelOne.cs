using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "StartScene")
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
