using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerExperience))]
[CanEditMultipleObjects]
public class ExperienceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerExperience expireince  = (PlayerExperience)target;

        Rect rect = GUILayoutUtility.GetRect(18, 28, "TextField");
        EditorGUI.ProgressBar(rect, expireince.CurrentExperience / expireince.MaxExperience, $"Experience({expireince.CurrentExperience} / {expireince.MaxExperience}" + $" Lvl:{expireince.Lvl}");

        if(GUILayout.Button("Add experience"))
        {
            
        }

        base.OnInspectorGUI();

    }
}
