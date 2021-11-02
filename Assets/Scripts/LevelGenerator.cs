using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int[,] levelMap;
    public Sprite outsideCorner;
    public Sprite outsideWall;
    public Sprite insideCorner;
    public Sprite insideWall;
    public Sprite Tjunction;
    public Sprite powerPellet;
    public Sprite Pellet;
    public float Vertical1, Horizontal1;
    public float Vertical2, Horizontal2;
    public float Vertical3, Horizontal3;
    public float Vertical4, Horizontal4;
    public bool use;
    public Button play;
    public int p;
    public RuntimeAnimatorController animator;                                                               
    public int[,] levelMap111 = { { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 }, //0-27  1-28
                                  { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 }, 
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 }, 
                                  { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 }, 
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 }, 
                                  { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 }, 
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 }, 
                                  { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 }, 
                                  { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 }, 
                                  { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4, 0, 3, 4, 4, 3, 4, 5, 1, 2, 2, 2, 2 ,1 }, 
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3, 0, 3, 4, 4, 3, 4, 5, 2, 0, 0, 0, 0, 0 }, 
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 }, 
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 }, 
                                  { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 3, 3, 5, 1, 2, 2, 2, 2, 2,}, 
                                  { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0,},
                                  { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 3, 3, 5, 1, 2, 2, 2, 2, 2,},
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                  { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3, 0, 3, 4, 4, 3, 4, 5, 2, 0, 0, 0, 0, 0 },
                                  { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4, 0, 3, 4, 4, 3, 4, 5, 1, 2, 2, 2, 2 ,1 },
                                  { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 },
                                  { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 },
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 },
                                  { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                  { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 },
                                  { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                  { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                  { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },};
                                                                                                                      //0-28 1-29
    public int[,] levelMap31 = new int[,] { 
                                            
                                            
                                            
                                            
                                           
                                            
                                            
                                            

                                            
                                            {0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },};


    public void emptyGameobject()
    {
        foreach (GameObject g in SceneManager.GetSceneByName("Level1").GetRootGameObjects())
        {
            if (g.tag != "Level1")
            {
                g.SetActive(false);
            }
        }
        use = true;
    }

    void Awake()
    {
        use = false;
        p = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (use == true)
        {
            Vertical1 = 7.8f;
            Horizontal1 = 15.6f;
            Vertical2 = 7.8f;
            Horizontal2 = 1.5f;
            Vertical3 = 20f;
            Horizontal3 = 15.6f;
            Vertical4 = 20f;
            Horizontal4 = 1.5f;

            levelMap = new int[,] {  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0 },
                                 { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 4, 0, 0, 0 },
                                 { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 },
                                 { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 },
                                 { 0, 0, 0, 0, 0, 2, 5, 4, 0, 4, 4, 3, 0, 3 },
                                 { 1, 2, 2, 2, 2, 1, 5, 4, 0, 4, 4, 3, 0, 4 },
                                 { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 },
                                 { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 0 },
                                 { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 },
                                 { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                                 { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 },
                                 { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 },
                                 { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 },
                                 { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 },
                                 { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 }, };
            int[,] levelMap1 = new int[,] { {0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 4, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {3, 0, 3, 4, 4, 0, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {4, 0, 3, 4, 4, 0, 4, 5, 1, 2, 2, 2, 2 ,1 },
                                            {4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 },
                                            {0, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 },
                                            {4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                            {3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 },
                                            {4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                            {7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 } };

            int[,] levelMap2 = new int[,] { { 1,2,2,2,2,2,2,2,2,2,2,2,2,7},
                                            { 2,5,5,5,5,5,5,5,5,5,5,5,5,4},         
                                            { 2,5,3,4,4,3,5,3,4,4,4,3,5,4},         
                                            { 2,6,4,0,0,4,5,4,0,0,0,4,5,4},         
                                            { 2,5,3,4,4,3,5,3,4,4,4,3,5,3},         
                                            { 2,5,5,5,5,5,5,5,5,5,5,5,5,5},         
                                            { 2,5,3,4,4,3,5,3,3,5,3,4,4,4},         
                                            { 2,5,3,4,4,3,5,4,4,5,3,4,4,0},         
                                            { 2,5,5,5,5,5,5,4,4,5,5,5,5,4},         
                                            { 1,2,2,2,2,1,5,4,0,4,4,3,0,4},         
                                            { 0,0,0,0,0,2,5,4,0,4,4,3,0,3},         
                                            { 0,0,0,0,0,2,5,4,4,0,0,0,0,0},         
                                            { 0,0,0,0,0,2,5,4,4,0,3,4,4,0},                  };
            int[,] levelMap3 = new int[,] { {7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
                                            {4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                            {4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 },
                                            {3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                                            {4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 },
                                            {0, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 },
                                            {4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 },
                                            {4, 0, 3, 4, 4, 0, 4, 5, 1, 2, 2, 2, 2 ,1 },
                                            {3, 0, 3, 4, 4, 0, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                                            {0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },};

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (levelMap[j, i] == 1)
                    {
                        GameObject g = new GameObject("Outside Corner");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f) + 0.2f, j - (Vertical1 - 0.5f) - 0.2f);
                        if (j == 5 && i == 0)
                        {
                            g.transform.Rotate(180, 0, 0, 0);
                            g.transform.position = new Vector3(i - (Horizontal1 - 0.5f) + 0.2f, j - (Vertical1 - 0.5f) + 0.25f);
                        }
                        if (j == 5 && i == 5)
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                            g.transform.position = new Vector3(i - (Horizontal1 - 0.5f) - 0.25f, j - (Vertical1 - 0.5f) - 0.2f);
                        }
                        if (j == 1 && i == 5)
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                            g.transform.position = new Vector3(i - (Horizontal1 - 0.5f) - 0.25f, j - (Vertical1 - 0.5f) + 0.2f);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideCorner;
                    }
                    if (levelMap[j, i] == 2)
                    {
                        GameObject g = new GameObject("Outside Wall");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f));
                        if (j > 5 && i == 0)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        if (j > 0 && i == 5 && j < 5)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideWall;
                    }
                    if (levelMap[j, i] == 3)
                    {
                        GameObject g = new GameObject("Inside Corner");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f));
                        if ((i == 2 && j == 12) || (i == 7 && j == 12) || (i == 2 && j == 8) || (i == 7 && j == 8) || (i == 10 && j == 2) || (i == 8 && j == 4)||((i == 10 && j == 8)))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((i == 5 && j == 12) || (i == 11 && j == 12) || (i == 5 && j == 8) || (i == 8 && j == 8) || (i == 11 && j == 5) || (i == 13 && j == 7)||(j==9&&i==11))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if ((i == 5 && j == 10) || (i == 11 && j == 10) || (i == 5 && j == 7) || (i == 8 && j == 1) || (i == 11 && j == 4))
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideCorner;
                    }
                    if (levelMap[j, i] == 4)
                    {
                        GameObject g = new GameObject("Inside Wall");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f));
                        if ((j == 8 && i > 2) || (j == 12 && (i == 3 || i == 4 || i > 7 && i < 11)) || (j == 5 && i > 8 && i < 11) || (j == 2 && i > 10))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if (((j == 11 || j > 1) && (i == 2 || i == 7)))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((j == 11 && (i == 5 || i == 11)))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        if (i == 8 && j > 1 && j < 8)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        if (i==7&&j==1)
                        {
                            g.transform.Rotate(0,0,270,0);
                        }
                        if (i == 8 && j == 1)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        if (((j < 14 && j > 10) || (j > 4 && j < 7) && i == 13) || (i == 10 && j < 2))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((j == 12 && i > 2 && i < 11) || (j == 11 && (i == 2 || i == 5 || i == 7 | i == 11)))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }

                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideWall;
                    }
                    if (levelMap[j, i] == 5)
                    {
                        GameObject g = new GameObject("Pellet");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Pellet;
                    }
                    if (levelMap[j, i] == 6)
                    {
                        GameObject g = new GameObject("Power Pellet");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f));
                        g.transform.localScale = new Vector3(3, 3, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = powerPellet;
                        var a = g.AddComponent<Animator>();
                        a.runtimeAnimatorController = animator;
                    }
                    if (levelMap[j, i] == 7)
                    {
                        GameObject g = new GameObject("T junction");
                        g.transform.position = new Vector3(i - (Horizontal1 - 0.5f), j - (Vertical1 - 0.5f) - 0.1f);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Tjunction;
                    }
                }
            }
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (levelMap1[j, i] == 1)
                    {
                        GameObject g = new GameObject("Outside Corner");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        if(i==13 && j == 14)
                        {
                            g.transform.position = new Vector3(i - (Horizontal2 - 0.26f), j - (Vertical2 - 0.27f));
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if (i == 13 && j == 5)
                        {
                            g.transform.position = new Vector3(i - (Horizontal2 - 0.5f)-0.24f, j - (Vertical2 - 0.5f)+0.28f);
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if (i == 8 && j == 5)
                        {
                            g.transform.position = new Vector3(i - (Horizontal2 - 0.74f), j - (Vertical2 - 0.3f));
                            g.transform.Rotate(0, 0, 0, 0);
                        }
                        if (i == 8 && j == 1)
                        {
                            g.transform.position = new Vector3(i - (Horizontal2 - 0.5f) + 0.21f, j - (Vertical2 - 0.5f)+0.27f);
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideCorner;
                    }
                    if (levelMap1[j, i] == 2)
                    {
                        GameObject g = new GameObject("Outside Wall");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        if((i==13 && j>5 && j < 14)|| (i == 8 && j>0 && j<5 ))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideWall;
                    }
                    if (levelMap1[j, i] == 3)
                    {
                        GameObject g = new GameObject("Inside Corner");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        if ((j==10&&(i==0||i==6||i==11))||(j==7&&(i==3||i==11))||(j==4&& i==0)||(j==1&&i==6))
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        if ((j==12&&(i==2||i==8)||(j==8&&(i==5||i==8))||(j==5&&i==2)))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((j==12 && (i==6||i==11))||(j==8&&(i==3||i==6||i==11))||(j==2&&i==3))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideCorner;
                    }
                    if (levelMap1[j, i] == 4)
                    {
                        GameObject g = new GameObject("Inside Wall");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        if ((i==0&&j>10&&j<14)||(i==0&&j<7&&j>4)||(i==6&&j==11)||(i==11&&j==11)||(i==6&&j<8&&j>1)||(i==3&&j<2))
                        {
                            g.transform.Rotate(0,0,90,0);
                        }
                        if ((j==12&&i<6&&i>2)||(j==12&&i>8&&i<11)||(j==8&&i<11&i>8)||(j==8&&i>=0&&i<3)||(j==5&&i<5&&i>2)||(j==2&&i<3&&i>0))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if ((i==5&&j<8&&j>1)||(j==11&&(i==2||i==8)))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if (i == 5 && j == 1)
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if (i == 6 && j == 1)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideWall;
                    }
                    if (levelMap1[j, i] == 5)
                    {
                        GameObject g = new GameObject("Pellet");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Pellet;
                    }
                    if (levelMap1[j, i] == 6)
                    {
                        GameObject g = new GameObject("Power Pellet");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f), j - (Vertical2 - 0.5f));
                        g.transform.localScale = new Vector3(3, 3, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = powerPellet;
                        var a = g.AddComponent<Animator>();
                        a.runtimeAnimatorController = animator;
                    }
                    if (levelMap1[j, i] == 7)
                    {
                        GameObject g = new GameObject("T junction");
                        g.transform.position = new Vector3(i - (Horizontal2 - 0.5f)+0.03f, j - (Vertical2 - 0.5f)-0.1f);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Tjunction;
                    }
                }
            }
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (levelMap2[j, i] == 1)
                    {
                        GameObject g = new GameObject("Outside Corner");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f) +0.25f, j - (Vertical3 - 0.5f)-0.2f);
                        if (i == 5 && j == 9)
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                            g.transform.position = new Vector3(i - (Horizontal3 - 0.5f) - 0.27f, j - (Vertical3 - 0.5f) + 0.26f);
                        }
                        if (i == 0 && j == 0)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                            g.transform.position = new Vector3(i - (Horizontal3 - 0.5f) + 0.2f, j - (Vertical3 - 0.5f) + 0.25f);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideCorner;
                    }
                    if (levelMap2[j, i] == 2)
                    {
                        GameObject g = new GameObject("Outside Wall");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f));
                        if ((i == 0 && j < 9 && j > 0) || (i == 5 && j <= 12 && j > 9))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideWall;
                    }
                    if (levelMap2[j, i] == 3)
                    {
                        GameObject g = new GameObject("Inside Corner");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f));
                        if ((j==4&&(i==2||i==7||i==13))||(j==7&&i==10)||(j==7&&i==2)|| (i == 10 && j == 8)||(i==13&&j==10))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((j == 4 && (i == 5 || i == 11)) || (i == 5 && j == 7) || (i == 11 && j == 10))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if ((j==2&&(i==5||i==11))||(j==6&&(i==5||i==8))||(j==9&&i==11))
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideCorner;
                    }
                    if (levelMap2[j, i] == 4)
                    {
                        GameObject g = new GameObject("Inside Wall");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f));
                        if ((j == 7 && i > 2 && i < 5) || (j == 4 && i > 2 && i < 5) || ((j == 4 && i > 7 && i < 11)) || (j == 7 && i < 13 && i > 10)||(j==10&&i>8&&i<11))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if ((j == 3 && i == 2) || (j == 3 && i == 7) || (i == 13 && j > 0 && j < 4) || (i == 13 && j > 7 && j < 10) || (i == 7 && j > 6 && j <= 12))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((j == 3 && i == 5) || (j == 3 && i == 11) || (i == 8 && j > 6 && j < 9)|| (i==8&&j>10&&j<=12))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideWall;
                    }
                    if (levelMap2[j, i] == 5)
                    {
                        GameObject g = new GameObject("Pellet");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Pellet;
                    }
                    if (levelMap2[j, i] == 6)
                    {
                        GameObject g = new GameObject("Power Pellet");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f));
                        g.transform.localScale = new Vector3(3, 3, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = powerPellet;
                        var a = g.AddComponent<Animator>();
                        a.runtimeAnimatorController = animator;
                    }
                    if (levelMap2[j, i] == 7)
                    {
                        GameObject g = new GameObject("T junction");
                        g.transform.position = new Vector3(i - (Horizontal3 - 0.5f), j - (Vertical3 - 0.5f)+0.16f);
                        g.transform.Rotate(180, 0, 0, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Tjunction;
                    }
                }
            }
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (levelMap3[j, i] == 1)
                    {
                        GameObject g = new GameObject("Outside Corner");
                        if (i==13 && j==0)
                        {
                            g.transform.position = new Vector3(i - (Horizontal4 - 0.5f)-0.28f, j - (Vertical4 - 0.5f)+0.23f);
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if (i==13 && j==9)
                        {
                            g.transform.position = new Vector3(i - (Horizontal4 - 0.5f)-0.24f, j - (Vertical4 - 0.5f)-0.24f);
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if(i==8 && j == 9)
                        {
                            g.transform.position = new Vector3(i - (Horizontal4 - 0.5f) +0.2f, j - (Vertical4 - 0.5f)+0.285f);
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideCorner;
                    }
                    if (levelMap3[j, i] == 2)
                    {
                        GameObject g = new GameObject("Outside Wall");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f));
                        if ((i==13&&j>0&&j<9)||(i==8&&j>9&&j<=12))
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideWall;
                    }
                    if (levelMap3[j, i] == 3)
                    {
                        GameObject g = new GameObject("Inside Corner");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f));
                        if ((j == 4 && (i == 0 || i == 6 | i == 11)) || (i == 11 && j == 7) || (j == 10 && i == 0) || (j == 7 || i == 3))
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if ((j == 2 && (i == 6 || i == 11)) || (j == 6 && (i == 3 || i == 6 || i == 11)))
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        if (j == 12 && i == 3)
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if (j == 8 && i == 8)
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        if ((j == 10 && i == 2) || (i == 2 && j == 4) || (j == 4 && i == 8))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if (i == 3 && j == 12)
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        if (i == 3 && j == 6)
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                        }
                        if (i == 8 && j == 7)
                        {
                            g.transform.Rotate(0, 180, 0, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideCorner;
                    }
                    if (levelMap3[j, i] == 4)
                    {
                        GameObject g = new GameObject("Inside Wall");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f));
                        if ((j==4&&i<6&&i>2)||(j==4&&i>8&&i<11)||(j==7&&i>0&&i<3)||(j==7&&i>8&&i<11)||(j==10&&i>2&&i<5))
                        {
                            g.transform.Rotate(0,0,180,0);
                        }
                        if ((i==0&&j>0&&j<4)||(i==0&&j>7&&j<10)||(i==6&&j==3)||(i==6&&j>6&&j<=12)||(j==3&&i==11))
                        {
                            g.transform.Rotate(0,0,90,0);
                        }
                        if ((j==3&&i==2)||(j==3&&i==8)||(i==5&&j>6&&j<9)||(i==5&&j>10&&j<=12))
                        {
                            g.transform.Rotate(0,0,270,0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = insideWall;
                    }
                    if (levelMap3[j, i] == 5)
                    {
                        GameObject g = new GameObject("Pellet");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Pellet;
                    }
                    if (levelMap3[j, i] == 6)
                    {
                        GameObject g = new GameObject("Power Pellet");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f));
                        g.transform.localScale = new Vector3(3, 3, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = powerPellet;
                        var a = g.AddComponent<Animator>();
                        a.runtimeAnimatorController = animator;
                    }
                    if (levelMap3[j, i] == 7)
                    {
                        GameObject g = new GameObject("T junction");
                        g.transform.position = new Vector3(i - (Horizontal4 - 0.5f), j - (Vertical4 - 0.5f)+0.16f);
                        g.transform.Rotate(180, 0, 0, 0);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Tjunction;
                    }
                }
            }
            use = false;
        }
        
    }
}
