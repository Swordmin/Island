using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector3 _velocityDirect;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _shadow;

    private void Update()
    {
        Move();
        AnimatorControl();
    }

    private void Move() 
    {
        float horizontal = Input.GetAxis("Horizontal") * _speed;
        float vertical = Input.GetAxis("Vertical") * _speed;
        _rigidbody.velocity = new Vector2(horizontal, vertical);
        _shadow.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void AnimatorControl() 
    {
        if(Mathf.Abs(_rigidbody.velocity.magnitude) > 0) 
        {
            _animator.Play("Run");
        }
        if(Mathf.Abs(_rigidbody.velocity.magnitude) == 0)
        {
            _animator.Play("Idle");
        }

        if((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) > 0 ) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }


}
