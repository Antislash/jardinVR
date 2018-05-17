using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    private int num;
    private float scale;

    // Use this for initialization
    void Start()
    {
        num = Int32.Parse(gameObject.tag[gameObject.tag.Length - 1].ToString());
        scale = 0;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        scale = Manager.Instance.length[num] - Manager.Instance.tailleFlower[Manager.Instance.flower[num]];
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
