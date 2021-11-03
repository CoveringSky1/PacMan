using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMove : MonoBehaviour
{
    public GameObject pacMan;
    private Vector2 endPos;
    private Vector2 startPos;
    public float duration;
    private Transform Target;
    private float time;
    private int current;
    public int Z;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Target = pacMan.transform;
        duration = 100f;
        current = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (current == 1)
        {
            endPos = new Vector2(-9.27f, 5.53f);
            startPos = Target.position;

            float distance = Vector3.Distance(Target.position, endPos);
            if (distance > 0.1f)
            {
                Target.position = Vector3.Lerp(startPos, endPos, time / duration);
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                Target.position = endPos;
                time = 0;
                current = 2;
                pacMan.transform.Rotate(0, 0, -90);
            }
        }
        if (current == 2)
        {
            endPos = new Vector2(-9.27f, 1.58f);
            startPos = Target.position;

            float distance = Vector3.Distance(Target.position, endPos);
            if (distance > 0.1f)
            {
                Target.position = Vector3.Lerp(startPos, endPos, time / duration);
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                Target.position = endPos;
                time = 0;
                current = 3;
                pacMan.transform.Rotate(0, 0, -90);
            }
        }

        if (current == 3)
        {
            endPos = new Vector2(-14.25f,1.585f);
            startPos = Target.position;

            float distance = Vector3.Distance(Target.position, endPos);
            if (distance > 0.1f)
            {
                Target.position = Vector3.Lerp(startPos, endPos, time / duration);
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                Target.position = endPos;
                time = 0;
                current = 4;
                pacMan.transform.Rotate(0, 0, -90);
            }
        }
        if (current == 4)
        {
            endPos = new Vector2(-14.25f, 5.53f);
            startPos = Target.position;

            float distance = Vector3.Distance(Target.position, endPos);
            if (distance > 0.1f)
            {
                Target.position = Vector3.Lerp(startPos, endPos, time / duration);
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                Target.position = endPos;
                time = 0;
                current = 1;
                pacMan.transform.Rotate(0, 0, -90);
            }
        }
    }
}
