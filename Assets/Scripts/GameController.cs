using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private List<SO_ClockVariant> _clockVariants;
    public List<SO_ClockVariant> ClockVariants
    {
        get => _clockVariants;
    }
    [SerializeField]
    private SO_ClockVariant _currentClockVariant;
    public SO_ClockVariant CurrentClockVariant
    {
        get 
        {
            if (_currentClockVariant == null)
            {
                _currentClockVariant = _clockVariants[0];
            }

            return _currentClockVariant;
        }
    }
    [SerializeField]
    private UnityEvent _clockSettingsChanged;

    private Vector3 _screenPosition;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _screenPosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(_screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                IInteractable interactableObj = hitData.collider.GetComponent<IInteractable>();
                if (interactableObj != null)
                {
                    interactableObj.Interact();
                }
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _screenPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(_screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hitData))
                {
                    IInteractable interactableObj = hitData.collider.GetComponent<IInteractable>();
                    if (interactableObj != null)
                    {
                        interactableObj.Interact();
                    }
                }
            }
        }
    }

    public void NextClockVariant()
    {
        int currentIndex = _clockVariants.FindIndex((x) => x == _currentClockVariant);
        currentIndex++;
        if (currentIndex > _clockVariants.Count - 1)
        {
            _currentClockVariant = _clockVariants[0];
        }
        else
        {
            _currentClockVariant = _clockVariants[currentIndex];
        }
        _clockSettingsChanged.Invoke();
    }

    public void PreviousClockVariant()
    {
        int currentIndex = _clockVariants.FindIndex((x) => x == _currentClockVariant);
        currentIndex--;
        if (currentIndex < 0)
        {
            _currentClockVariant = _clockVariants[_clockVariants.Count - 1];
        }
        else
        {
            _currentClockVariant = _clockVariants[currentIndex];
        }
        _clockSettingsChanged.Invoke();
    }
}
