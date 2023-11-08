using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private GameObject _hourClockRoot;
    [SerializeField]
    private GameObject _minuteClockRoot;
    [SerializeField]
    private GameObject _secondsClockRoot;

    [SerializeField]
    private float _hourRotation;
    [SerializeField]
    private float _minuteRotation;
    [SerializeField]
    private float _secondsRotation;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DateTime.Now.Hour);
    }

    // TODO: Refactor this
    void FixedUpdate()
    {
        _hourRotation = 360f / ((24f / DateTime.Now.Hour) / 2f);
        _hourClockRoot.transform.localRotation = Quaternion.Euler(0f, _hourRotation, 0f);

        _minuteRotation = 360f / (60f / DateTime.Now.Minute);
        _minuteClockRoot.transform.localRotation = Quaternion.Euler(0f, _minuteRotation, 0f);

        _secondsRotation = 360f / (60f / ((float)DateTime.Now.Second + 1f));
        _secondsClockRoot.transform.localRotation = Quaternion.Euler(0f, _secondsRotation, 0f);
    }
}
