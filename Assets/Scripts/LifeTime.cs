using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    //public float m_lifetime = 3f;
    public float m_speedThreshold = 0.2f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       // Destroy(gameObject, m_lifetime);
    }

    private void Update()
    {
        if (rb.velocity.magnitude <= m_speedThreshold)
            Destroy(gameObject);
    }
}
