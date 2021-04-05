using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float _max;
    [SerializeField] private float _health;


    public void GetDamage(float _damage) 
    {
        if (_health > 0)
            _health -= _damage;
        else
            DestroyObj();

        GetComponent<Animator>()?.Play("Damage");

    }

    public void Start()
    {
        
    }

    public void Healling(float _heal) 
    {
        _health += _heal;
    }

    public void Kick(Vector3 _direction, float _force) 
    {
        GetComponent<Rigidbody2D>()?.AddForce(_direction * _force, ForceMode2D.Impulse);
        
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

}
