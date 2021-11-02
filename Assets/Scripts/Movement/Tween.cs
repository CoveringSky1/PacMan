using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 startPos { get; private set; }
    public Vector3 endPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform target, Vector3 startpos, Vector3 endpos, float starttime, float duration)
    {
        this.Target = target;
        this.startPos = startpos;
        this.endPos = endpos;
        this.StartTime = starttime;
        this.Duration = duration;
    }
}
