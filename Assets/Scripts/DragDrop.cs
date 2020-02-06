using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public LayerMask m_effectorLayerMask;
    //public LayerMask m_circleLayerMask;
    public BoolVariable isResizing;
    public BoolVariable isDragging;

    private Camera _mainCamera;
    private Transform objectToDrag;

    private void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isDragging.value = false;
    }

    /*private void Update()
    {
        //Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (!isResizing.value)
        {
            if (Input.GetButton("Fire1"))
            {
                //Debug.Log("Drag");
                Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);


                RaycastHit2D hit;
                hit = Physics2D.Raycast(
                            mousePosition,
                            Vector2.zero,
                            Mathf.Infinity,
                            m_effectorLayerMask
                            );

                if (hit.collider != null)
                {
                    //objectToDrag = hit.transform;
                    isDragging.value = true;
                    ObjectFollowMouse(mousePosition, hit.collider.transform);
                }

            }
            else
                isDragging.value = false;
        }
    }*/

    private void Update()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        OnDrag(mousePosition);
        OnDown(mousePosition);
        OnUp(mousePosition);

    }

    /*
    private void ObjectFollowMouse(Vector2 mousePosition, Transform trObject)
    {
        Vector3 mousePosition3D = new Vector3(mousePosition.x, mousePosition.y, 0f);
        trObject.position = mousePosition3D;
    }
    */

    private void OnDrag(Vector2 mousePosition)
    {
        if (Input.GetButton("Fire1") && objectToDrag != null)
        {
            objectToDrag.position = mousePosition;
        }
    }

    private void OnDown(Vector2 mousePosition)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(
                        mousePosition,
                        Vector2.zero,
                        Mathf.Infinity,
                        m_effectorLayerMask
                        );

            if (hit.collider != null)
            {
                objectToDrag = hit.transform;
                isDragging.value = true;
            }
        }
    }

    private void OnUp(Vector2 mousePosition)
    {
        if (Input.GetButtonUp("Fire1"))
        {
            objectToDrag = null;
            isDragging.value = false;
        }
    }
}
