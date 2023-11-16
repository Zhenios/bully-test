using System;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject _clockRoot;

    [SerializeField]
    private GameObject _hourClockRoot;
    [SerializeField]
    private GameObject _minuteClockRoot;
    [SerializeField]
    private GameObject _secondsClockRoot;
    [SerializeField]
    private TextMeshPro _textMesh;
    [SerializeField]
    private float _rotationSpeed = 15f;

    private float _hourRotation;
    private float _minuteRotation;
    private float _secondsRotation;
    private DateTime _dateTimeOffset;

    void Start()
    {
        SetClockSettings();
    }

    // TODO: Refactor this
    void FixedUpdate()
    {
        ClockLoop();

        this.transform.Rotate(0f, Time.deltaTime * _rotationSpeed, 0f);
    }

    void ClockLoop()
    {
        _hourRotation = 360f / ((24f / _dateTimeOffset.Hour) / 2f);
        _hourClockRoot.transform.localRotation = Quaternion.Euler(0f, _hourRotation, 0f);

        _minuteRotation = 360f / (60f / DateTime.Now.Minute);
        _minuteClockRoot.transform.localRotation = Quaternion.Euler(0f, _minuteRotation, 0f);

        _secondsRotation = 360f / (60f / ((float)DateTime.Now.Second + 1f));
        _secondsClockRoot.transform.localRotation = Quaternion.Euler(0f, _secondsRotation, 0f);
    }

    public void SetClockSettings()
    {
        var clockSettings = GameController.Instance.CurrentClockVariant;

        _dateTimeOffset = DateTime.Now.AddHours(clockSettings.Offset);

        _textMesh.text = clockSettings.DayNames[(int)DateTime.Now.DayOfWeek];

        var secondHandMeshRenderer = _secondsClockRoot.GetComponentInChildren<MeshRenderer>();
        secondHandMeshRenderer.material = clockSettings.SecHandMaterial;
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
