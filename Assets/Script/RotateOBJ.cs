﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles -= new Vector3(0,0,360*Time.deltaTime);
    }
}
