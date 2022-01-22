using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Shadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    private void Update()
    {
        if(_sprite)
            GetComponent<SpriteRenderer>().sprite =  _sprite.sprite;
    }
}
