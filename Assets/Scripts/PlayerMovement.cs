using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector3 _velocityDirect;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

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
            transform.localScale = new Vector3(1,1,1);
        }
        if((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }
    }


}
