using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // Start is called before the first frame update
    private Tween activeTween;
    private List<Tween> activeTweens;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            Debug.Log(distance);
            if (distance > 0.1f)
            {
                Debug.Log(distance);
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos,
                                                           EaseInCubic(time / activeTween.Duration));
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                Debug.Log(distance);
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
                time = 0;
            }

        }


    }

    public float EaseInCubic(float t) { return t * t * t; }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }
}
