using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float m_lifetime = 3f;
    void Start()
    {
        Destroy(gameObject, m_lifetime);
    }
}
