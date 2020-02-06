using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeArea : MonoBehaviour
{
    public LayerMask m_circleLayerMask;
    public BoolVariable isResizing;
    public BoolVariable isDragging;

    private Camera _mainCamera;
    //private Vector2 _mousePositionStart;
    private Vector2 _mousePosition;
    private RaycastHit2D _hit;
    //private bool resizing;

    private void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isResizing.value = false;
    }

    void Update()
    {
        if (!isDragging.value)
        {
            _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetButton("Fire2"))
            {

                RaycastHit2D hit = Physics2D.Raycast(
                            _mousePosition,
                            Vector2.zero,
                            Mathf.Infinity,
                            m_circleLayerMask
                            );

                if (hit.collider != null || isResizing.value)
                {
                    if (hit.collider != null)
                        _hit = hit;

                    isResizing.value = true;
                    ResizeCircleArea(_hit.collider.transform);
                }
            }
            else
                isResizing.value = false;
        }
    }

    private void ResizeCircleArea(Transform trObject)
    {
        /*
        Vector2 diff = _mousePositionStart + (Vector2)trObject.position;
        _mousePositionStart = diff;
        _mousePosition += diff;
        */

        //float distance = Vector2.Distance(_mousePositionStart, _mousePosition);
        float distance = Vector2.Distance(trObject.parent.position, _mousePosition);

        Vector2 newScale = new Vector2(distance, distance);
        //Vector2 newScale = new Vector2(Mathf.Max(_mousePosition.x, _mousePosition.y), Mathf.Max(_mousePosition.x, _mousePosition.y));

        if (newScale.x > 0.85 && newScale.x < 2)
            trObject.localScale = newScale;
    }
}
