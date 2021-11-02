using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level1")
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}