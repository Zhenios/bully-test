using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField]
    private E_ButtonSide _buttonSide;
    [SerializeField]
    private AudioSource _audioSource;

    public void Interact()
    {
        switch (_buttonSide)
        {
            case E_ButtonSide.Left:
                GameController.Instance.PreviousClockVariant();
                _audioSource.Play();
                break;
            case E_ButtonSide.Right:
                GameController.Instance.NextClockVariant();
                _audioSource.Play();
                break;
            default:
                break;
        }
    }
}
