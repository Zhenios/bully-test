using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private List<SO_ClockVariant> _clockVariants;
    public List<SO_ClockVariant> ClockVariants
    {
        get => _clockVariants;
    }

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
                Debug.Log(hitData.collider.name);
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
                    Debug.Log(hitData.collider.name);
                }
            }
        }
    }
}
