using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    [SerializeField] private GameObject _crystall;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Health _health;


    [SerializeField] private GameObject _player;

    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _health.OnDie.AddListener(Die);
        _health.OnHit.AddListener(Hit);
    }

    private void OnEnable()
    {
        _collider.radius = _radius;
        _crystall = GameObject.Find("Crystall");
    }

    private void FixedUpdate()
    {
        AnimatorControll();
        Vector3 heading = _crystall.transform.position - transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; 
        _rigidbody.AddForce(direction * _speed, ForceMode2D.Force);
    }

    private void AnimatorControll() 
    {
        _animator.SetFloat("Magnitude", _rigidbody.velocity.magnitude);
        if (_crystall.transform.position.x > transform.position.x)
            _spriteRenderer.flipX = false;
        if (_crystall.transform.position.x < transform.position.x)
            _spriteRenderer.flipX = true;
    }

    private void Die() 
    {
        _animator.SetBool("Die", true);
    }

    private void Hit() 
    {
        
    }
}
