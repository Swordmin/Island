using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Health health = (Health)target;

        Rect rect = GUILayoutUtility.GetRect(18, 28, "TextField");
        EditorGUI.ProgressBar(rect, health.CurrentHealth / health.MaxHealth, $"Health({health.CurrentHealth} / {health.MaxHealth}");

        base.OnInspectorGUI();

    }

}
