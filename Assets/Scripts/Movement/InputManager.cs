using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pacman;
    private PacStudentController tweener;
    private string lastInput;
    private string currentInput;
    private string temp;
    public int x = 1;
    public int y = 1;
    public AudioSource walking;
    public int[,] level2      = { { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 }, //x0-27  1-28
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
                                  { 2, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 2,},
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
                                                                                                                     //y0-28 1-29

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<PacStudentController>();
        lastInput = null;
        currentInput = null;
        InvokeRepeating("movement", 0, 0.5f);
        walking.Play(0);
        walking.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        temp = lastInput;
        checkWall();
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = "a";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = "d";
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = "s";
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = "w";
        }

        
    }

    public void checkWall()
    {
        switch (lastInput)
        {
            case "a":
                if (level2[x, y - 1] == 5 || level2[x, y - 1] == 0)
                {
                    currentInput = "a";
                }else
                {
                    lastInput = currentInput;
                }
                break;
            case "d":
                if (level2[x, y + 1] == 5 || level2[x, y + 1] == 0)
                {
                    currentInput = "d";
                }else
                {
                    lastInput = currentInput;
                }
                break;
            case "s":
                if (level2[x + 1, y] == 5 || level2[x + 1, y] == 0)
                {
                    currentInput = "s";
                }else
                {
                    lastInput = currentInput;
                }
                break;
            case "w":
                if (level2[x - 1, y] == 5 || level2[x - 1, y] == 0)
                {
                    currentInput = "w";
                }else
                {
                    lastInput = currentInput;
                }
                break;
            default:
                lastInput = currentInput;
                break;
        }
    }

    public void movement()
    {
        Vector2 rightPos = new Vector2(pacman.transform.position.x+1, pacman.transform.position.y);
        Vector2 upPos = new Vector2(pacman.transform.position.x, pacman.transform.position.y + 1);
        Vector2 downPos = new Vector2(pacman.transform.position.x, pacman.transform.position.y -1);
        Vector2 leftPos = new Vector2(pacman.transform.position.x - 1, pacman.transform.position.y);
        switch (currentInput)
        {
            case "a":
                if (level2[x, y - 1] == 5 || level2[x, y - 1] == 0 || level2[x, y - 1] == 6)
                {
                    y = y - 1;
                    tweener.AddTween(pacman.transform, pacman.transform.position, leftPos, 0.5f);
                    pacman.transform.localRotation = Quaternion.Euler(0, 0, 180);
                    walking.UnPause();
                }
                else
                {
                    walking.Pause();
                }
                break;
            case "w":
                if (level2[x - 1, y] == 5 || level2[x - 1, y] == 0 || level2[x - 1, y] == 6)
                {
                    x = x - 1;
                    tweener.AddTween(pacman.transform, pacman.transform.position, upPos, 0.5f);
                    pacman.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    walking.UnPause();
                }
                else
                {
                    walking.Pause();
                }
                break;
            case "s":
                if (level2[x + 1, y] == 5 || level2[x + 1, y] == 0 || level2[x + 1, y] == 6)
                {
                    x = x + 1;
                    tweener.AddTween(pacman.transform, pacman.transform.position, downPos, 0.5f);
                    pacman.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    walking.UnPause();
                }
                else
                {
                    walking.Pause();
                }
                break;
            case "d":
                if (level2[x, y + 1] == 5 || level2[x, y + 1] == 0 || level2[x, y + 1] == 6)
                {
                    y = y + 1;
                    tweener.AddTween(pacman.transform, pacman.transform.position, rightPos, 0.5f);
                    pacman.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    walking.UnPause();
                }
                else
                {
                    walking.Pause();
                }
                break;
        }
        Debug.Log("lastInput=   " + lastInput);
        Debug.Log("currentInput=   " + currentInput);
    }

    public string getCurrentInput()
    {
        return currentInput;
    }
}
