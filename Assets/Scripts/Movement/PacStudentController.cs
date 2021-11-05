using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tween activeTween;
    private float time;
    public Animator animatorController;
    private string currentInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.endPos);
            if (distance > 0.1f)
            {
                activeTween.Target.position = Vector3.Lerp(activeTween.startPos, activeTween.endPos,
                                                           (time / activeTween.Duration));
                time += Time.deltaTime;
            }

            if (distance <= 0.1f)
            {
                activeTween.Target.position = activeTween.endPos;
                activeTween = null;
                time = 0;
            }
        }
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }

}
