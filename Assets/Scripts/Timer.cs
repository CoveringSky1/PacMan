using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.RoundToInt(time % 60).ToString("00");

        timer.text = minutes + ":" + seconds;
    }
}
