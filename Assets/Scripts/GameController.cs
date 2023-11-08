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
}
