using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtackState 
{
    Idle,
    Atack
}

public class PlayerAtack : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage;
    [SerializeField] private float _forceDamage;

    [SerializeField] private AtackState _state;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _animator.Play("Hit");
        }
    }

    public void GetState(AtackState __state) 
    {
        _state = __state;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_state == AtackState.Atack)
        {
            if (collision.gameObject.tag == "Enemy")
            {

                collision.GetComponent<Health>()?.GetDamage(_damage);
                Vector3 heading = collision.transform.position - transform.position;
                float distance = heading.magnitude;
                Vector3 direction = heading / distance; 
                collision.GetComponent<Health>()?.Kick(direction, _forceDamage);

            }
        }
    }

}
