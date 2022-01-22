using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField] private float _max;
    [SerializeField] private float _health; 
    public float CurrentHealth => _health; 
    public float MaxHealth => _max; 
    [SerializeField] private float _cooldownDamage;
    [SerializeField] private bool _canDamage;

    public UnityEvent OnDie;
    public UnityEvent OnHit;

    [SerializeField] private Image _healthBar;

    public void GetDamage(float _damage) 
    {
        if (_damage < 0 || !_canDamage)
            return;

        _health -= _damage;
        _healthBar.fillAmount = _health / _max;
        StartCoroutine(DamageCooldown());

        if (_health <= 0)
            OnDie?.Invoke();
        else
            OnHit?.Invoke();

        GetComponent<Animator>()?.Play("Damage");

    }

    public void Healling(float _heal) 
    {
        if(_heal > 0)
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

    private IEnumerator DamageCooldown() 
    {
        _canDamage = false;
        yield return new WaitForSeconds(_cooldownDamage);
        _canDamage = true;
    }

}
