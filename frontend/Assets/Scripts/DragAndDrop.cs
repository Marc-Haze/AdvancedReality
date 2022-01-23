using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject Camera;
    public bool over = false;
    void OnMouseOver()
    {
        over = true;
    }
    void OnMouseExit()
    {
        over = false;
    }
    void Update()
    {
        if (over)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.transform.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }
    }
}