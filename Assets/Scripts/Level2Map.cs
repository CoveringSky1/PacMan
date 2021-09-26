using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Level2Map : MonoBehaviour
{
    public int[,] levelMap;
    public Sprite outsideCorner;
    public Sprite outsideWall;
    public Sprite insideCorner;
    public Sprite insideWall;
    public Sprite Tjunction;
    public Sprite powerPellet;
    public Sprite Pellet;
    public int Vertical, Horizontal;
    public bool use;

    void Awake()
    {
        if(use == true)
        {
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        levelMap = new int[,] {  { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 },
                                 { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 },
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

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (levelMap[j, i] == 1)
                    {
                        GameObject g = new GameObject("Outside Corner");
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f) + 0.2f, j - (Vertical - 0.5f) - 0.2f);
                        if (j == 5 && i == 0)
                        {
                            g.transform.Rotate(180, 0, 0, 0);
                            g.transform.position = new Vector3(i - (Horizontal - 0.5f) + 0.2f, j - (Vertical - 0.5f) + 0.25f);
                        }
                        if (j == 5 && i == 5)
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                            g.transform.position = new Vector3(i - (Horizontal - 0.5f) - 0.25f, j - (Vertical - 0.5f) - 0.2f);
                        }
                        if (j == 1 && i == 5)
                        {
                            g.transform.Rotate(0, 0, 180, 0);
                            g.transform.position = new Vector3(i - (Horizontal - 0.5f) - 0.25f, j - (Vertical - 0.5f) + 0.2f);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideCorner;
                    }
                    if (levelMap[j, i] == 2)
                    {
                        GameObject g = new GameObject("Outside Wall");
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f));
                        if (j > 5 && i == 0)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        if (j > 1 && i == 5 && j < 5)
                        {
                            g.transform.Rotate(0, 0, 90, 0);
                        }
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = outsideWall;
                    }
                    if (levelMap[j, i] == 3)
                    {
                        GameObject g = new GameObject("Inside Corner");
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f));
                        if ((i == 2 && j == 12) || (i == 7 && j == 12) || (i == 2 && j == 8) || (i == 7 && j == 8) || (i == 10 && j == 2) || (i == 8 && j == 4) || (i == 10 && j == 8))
                        {
                            g.transform.Rotate(0, 0, 270, 0);
                        }
                        if ((i == 5 && j == 12) || (i == 11 && j == 12) || (i == 5 && j == 8) || (i == 8 && j == 8) || (i == 11 && j == 5) || (i == 13 && j == 7))
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
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f));
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
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Pellet;
                    }
                    if (levelMap[j, i] == 6)
                    {
                        GameObject g = new GameObject("Power Pellet");
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f));
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = powerPellet;
                    }
                    if (levelMap[j, i] == 7)
                    {
                        GameObject g = new GameObject("T junction");
                        g.transform.position = new Vector3(i - (Horizontal - 0.5f), j - (Vertical - 0.5f) - 0.1f);
                        var s = g.AddComponent<SpriteRenderer>();
                        s.sprite = Tjunction;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
