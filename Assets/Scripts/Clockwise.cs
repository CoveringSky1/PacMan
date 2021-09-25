using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clockwise : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    private List<GameObject> itemList;
    public Animator animatorController;
    private GameObject a;
    private GameObject b;
    private GameObject c;
    private GameObject d;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(-2f, 0.5f, 0.0f), 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(2f, 0.5f, 0.0f), 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(0f, 0.5f, -2.0f), 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(0f, 0.5f, 2.0f), 0.5f);
        }
    }
}
