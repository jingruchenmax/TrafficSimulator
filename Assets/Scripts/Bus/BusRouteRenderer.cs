using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BusRouteRenderer:MonoBehaviour
{
    private LineRenderer lineRenderer;
    Transform[] childs;
    public void RenderLines()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = transform.childCount;
        lineRenderer.SetColors(Color.blue, Color.blue);;
        for (int i = 0; i < transform.childCount; i++)
        {
            lineRenderer.SetPosition(i, transform.GetChild(i).transform.position);
        }

    }
}