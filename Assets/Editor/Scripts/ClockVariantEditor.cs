using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SO_ClockVariant))]
[CanEditMultipleObjects]
public class ClockVariantEditor : Editor
{
    SerializedProperty _secHandMaterial;
    SerializedProperty _dayNames;
    SerializedProperty _offset;
    void OnEnable()
    {
        _secHandMaterial = serializedObject.FindProperty("_secHandMaterial");
        _dayNames = serializedObject.FindProperty("_dayNames");
        _offset = serializedObject.FindProperty("_offset");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_secHandMaterial);
        EditorGUILayout.PropertyField(_dayNames);
        EditorGUILayout.PropertyField(_offset);
        serializedObject.ApplyModifiedProperties();
        GUIStyle style = new GUIStyle();
        
        if (_dayNames.arraySize != 7)
        {
            style.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Week must have 7 days, you have " + _dayNames.arraySize.ToString(), style);
        }
        else
        {
            style.normal.textColor = Color.green;
            EditorGUILayout.LabelField("Good job!", style);
        }
    }
}
