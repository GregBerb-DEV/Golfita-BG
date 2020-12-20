﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallMouseInput : MonoBehaviour
{
    private Vector2 _initialTouchPosition;
    private Vector2 _lastTouchPosition;
    private GolfBallForceHandler _forceHandler;
    private GolfBallLineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<GolfBallLineRenderer>();
        _forceHandler = GetComponent<GolfBallForceHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialTouchPosition = Input.mousePosition;
            _lastTouchPosition = Input.mousePosition;

            _forceHandler.SetForces(0, 0);

            _lineRenderer.StartLine();

        }
        else if (Input.GetMouseButton(0))
        {
            _lastTouchPosition = Input.mousePosition;

            float newForceX = (_initialTouchPosition.x - _lastTouchPosition.x) * 1f;
            float newForceY = (_initialTouchPosition.y - _lastTouchPosition.y) * 1f;
            _forceHandler.SetForces(newForceX, newForceY);

            _lineRenderer.UpdateLinePoint(newForceX, newForceY);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _forceHandler.ApplyForce();
            _lineRenderer.SetRendererActive(false);
        }
    }
}