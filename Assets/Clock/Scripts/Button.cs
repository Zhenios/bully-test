using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField]
    private E_ButtonSide _buttonSide; 

    public void Interact()
    {
        switch (_buttonSide)
        {
            case E_ButtonSide.Left:
                GameController.Instance.PreviousClockVariant();
                break;
            case E_ButtonSide.Right:
                GameController.Instance.NextClockVariant();
                break;
            default:
                break;
        }
    }
}
