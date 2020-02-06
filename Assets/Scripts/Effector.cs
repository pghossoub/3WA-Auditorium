using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Effector : MonoBehaviour
{
    
    private Transform _trParent;
    private float _localScale;
    private float _localToScript;

    private AreaEffector2D _areaEffector;

    private void Awake()
    {
        _trParent = GetComponentInParent<Transform>();
        _areaEffector = GetComponent<AreaEffector2D>();

        _localScale = _trParent.localScale.x;
        _localToScript = _localScale - 1;
    }
    void Update()
    {
        _areaEffector.forceMagnitude = _trParent.localScale.x - _localToScript;
    }
}
