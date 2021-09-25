using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMove : MonoBehaviour
{
    public Animator animatorController;
    public GameObject PacMan;
    public int Z;

    // Start is called before the first frame update
    void Start()
    {
        Z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (Z)
            {
                case 0:
                    animatorController.SetTrigger("-90");
                    Z = 90;
                    break;
                case -180:
                    animatorController.SetTrigger("+90");
                    Z = 90;
                    break;
                case -90:
                    animatorController.SetTrigger("0");
                    Z = 90;
                    break;
                case 90:
                    animatorController.SetTrigger("180");
                    Z = 90;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (Z)
            {
                case 0:
                    animatorController.SetTrigger("-90");
                    Z = -90;
                    break;
                case -180:
                    animatorController.SetTrigger("+90");
                    Z = -90;
                    break;
                case -90:
                    animatorController.SetTrigger("0");
                    Z = -90;
                    break;
                case 90:
                    animatorController.SetTrigger("180");
                    Z = -90;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (Z)
            {
                case 0:
                    animatorController.SetTrigger("180");
                    Z = -180;
                    break;
                case -180:
                    animatorController.SetTrigger("0");
                    Z = -180;
                    break;
                case -90:
                    animatorController.SetTrigger("+90");
                    Z = -180;
                    break;
                case 90:
                    animatorController.SetTrigger("-90");
                    Z = -180;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            switch (Z)
            {
                case 0:
                    animatorController.SetTrigger("0");
                    Z = 0;
                    break;
                case -180:
                    animatorController.SetTrigger("180");
                    Z = 0;
                    break;
                case -90:
                    animatorController.SetTrigger("-90");
                    Z = 0;
                    break;
                case 90:
                    animatorController.SetTrigger("+90");
                    Z = 0;
                    break;
            }
        }
    }
}
