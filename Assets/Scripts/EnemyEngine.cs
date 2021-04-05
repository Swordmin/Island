using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    [SerializeField] private GameObject _crystall;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;

    [SerializeField] private GameObject _player;

    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

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
        Vector3 direction = heading / distance; // This is now the normalized direction.
        _rigidbody.AddForce(new Vector2(direction.x, direction.y) * _speed, ForceMode2D.Force);
    }

    private void AnimatorControll() 
    {
        if (_rigidbody.velocity.magnitude > 0.1)
            GetComponent<Animator>().Play("Run");
        if (_crystall.transform.position.x > transform.position.x)
            GetComponent<SpriteRenderer>().flipX = false;
        if (_crystall.transform.position.x < transform.position.x)
            GetComponent<SpriteRenderer>().flipX = true;
    }

}
