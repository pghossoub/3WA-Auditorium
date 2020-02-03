using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour
{
    public float m_forceIntensity;

    private Rigidbody2D _rbObject;

    /*void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Enter");
        _rbObject = other.gameObject.GetComponent<Rigidbody2D>();
        _rbObject.AddForce(new Vector2(0, - m_forceIntensity));
    }
    */
}
