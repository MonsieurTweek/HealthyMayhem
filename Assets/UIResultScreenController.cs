﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResultScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResultScreen()
    {
        gameObject.SetActive(true);
    }

    public void HideResultScreen()
    {
        gameObject.SetActive(false);
    }
}
