using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceGUI : MonoBehaviour
{

    [SerializeField] private Image _bar;

    public void SetExperience(float value, float maxValue) 
    {
        _bar.fillAmount = maxValue / value;
    }

}
