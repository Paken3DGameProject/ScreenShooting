﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject can;

    // Start is called before the first frame update
    public int[] evnums = new int[8];
    Vector2[] mpos = new Vector2[8];
    bool[] isclick = new bool[8], preclick = new bool[8];
    public Transform[] cursors = new Transform[8];
    Transform[] pcursors = new Transform[8];
    public Transform[] guns = new Transform[8];
    double pre;
    void Start()
    {
        pre = 0;

        StartCoroutine(AppearCan());
    }

    // Update is called once per frame
    void Update()
    {
        mpos[0] = new Vector2(Input.mousePosition.x - 375, Input.mousePosition.y - 213) / 30;
        isclick[0] = Input.GetMouseButton(0);
        for(int i = 0; i < 8; i++)
        {
            cursors[i].position = new Vector3(mpos[i].x, mpos[i].y, 6.9f);
            guns[i].LookAt(cursors[i]);
            RaycastHit hit;
            Ray ray = new Ray(guns[i].position, cursors[i].position);
            if (Physics.Raycast(ray, out hit))
            {
                cursors[i].position = hit.point;
                if (isclick[i] && !preclick[i])
                {
                    
                }
            }
            preclick[i] = isclick[i];
        }
    }

    private IEnumerator AppearCan()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            var obj = Instantiate(can);
            obj.transform.position = new Vector3(Random.Range(-7, 7), 10f, 6.9f);
        }
    }
}
