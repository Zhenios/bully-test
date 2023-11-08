using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Clock", menuName = "Clock/Clock Variant", order = 1)]
public class SO_ClockVariant : ScriptableObject
{
    [SerializeField, Tooltip("Skin material for second hand")]
    private Material _secHandMaterial;
    [SerializeField]
    private List<string> _dayNames;

    [SerializeField, Range(-12, 12)]
    private int _offset;
}
