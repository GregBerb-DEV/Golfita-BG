﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallTouchInput : MonoBehaviour
{
    private Vector2 _initialTouchPosition;
    private Vector2 _lastTouchPosition;
    private Rigidbody rig;
    private GolfBallForceHandler _forceHandler;
    private GolfBallLineRenderer _lineRenderer;
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private Interface _interface = default;


    void Start()
    {
        _lineRenderer = GetComponent<GolfBallLineRenderer>();
        _forceHandler = GetComponent<GolfBallForceHandler>();
    }

    void Update()
    {
        _interface.HideVaiDisplay();
        int currentTouch;
        rig = GetComponent<Rigidbody>();
        if ((rig.velocity.x < 0.2f && rig.velocity.x > -0.2f) && (rig.velocity.y < 0.2f && rig.velocity.y > -0.2f) && (rig.velocity.z < 0.2f && rig.velocity.z > -0.2f))
        {
            rig.velocity = new Vector3(0, 0, 0);
            _interface.ShowVaiDisplay();

            rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            _destroyer.setLastStop(GetComponent<Rigidbody>().position);
            for (currentTouch = 0; currentTouch < Input.touchCount; currentTouch++)
            {
                Touch touch = Input.GetTouch(currentTouch);
                if (touch.phase == TouchPhase.Began)
                {
                    _initialTouchPosition = touch.position;
                    _lastTouchPosition = touch.position;

                    _forceHandler.SetForces(0, 0);

                    _lineRenderer.StartLine();

                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    _lastTouchPosition = touch.position;

                    float newForceX = (_initialTouchPosition.x - _lastTouchPosition.x) * 1f;
                    float newForceY = (_initialTouchPosition.y - _lastTouchPosition.y) * 1f;
                    Vector2 newForces = _forceHandler.SetForces(newForceX, newForceY);

                    _lineRenderer.UpdateLinePoint(newForces);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _forceHandler.ApplyForce();
                    _lineRenderer.SetRendererActive(false);
                }
            }
        }

    }
}
