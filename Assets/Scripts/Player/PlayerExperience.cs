using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{

    [SerializeField] private float _max;
    public float MaxExperience => _max;

    [SerializeField] private float _current;
    public float CurrentExperience => _current;

    [SerializeField] private int _lvl;
    public int Lvl => _lvl;


    public void AddExperience(float value) 
    {
        _current += value;
        if(_current >= _max)
        {

           _lvl++;
            _current = _current - _max;
            _max *= 1.5f;

        }
    }

}
