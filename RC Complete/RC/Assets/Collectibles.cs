﻿using UnityEngine;
using System.Collections;

public class Collectibles : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        gameObject.transform.Rotate(new Vector3(90, 90, 90) * Time.deltaTime);
    }


}
