﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murenzhuang : MonoBehaviour
{
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime ,0,Space.World );
        // transform.eulerAngles = new Vector3(0,25*Time.deltaTime,0);
    }
}
