using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFixed : MonoBehaviour
{

    [SerializeField] private float _offcet;

    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)((transform.position.y * 100) + _offcet);
    }

    public void Start()
    {
    }
}
