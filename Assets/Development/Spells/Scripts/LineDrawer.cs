using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] float lineLength = 50f;
    bool enable;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        EnableLine(false);
    }

    public void EnableLine(bool enable)
    {
        lineRenderer.enabled = enable;
        this.enable = enable;
    }
    private void Update()
    {
        if (!enable) return;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * lineLength);
    }
}
