using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string yourdate = DateTime.Today.DayOfWeek.ToString();
        Debug.Log(yourdate);

        int day = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
        Debug.Log(day);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
