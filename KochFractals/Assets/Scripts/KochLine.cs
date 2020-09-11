using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator
{
    LineRenderer _lineRenderer;
    [Range(0,1)]
    public float lerpAmount;
    public float generateMultiplier;
    Vector3[] _lerpPosition;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = true;
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.loop = true;
        _lineRenderer.positionCount = _position.Length;
        _lineRenderer.SetPositions(_position);
    }

    // Update is called once per frame
    void Update()
    {
        if(_generationCount != 0)
        {
            for(int i = 0; i < _position.Length; i++)
            {
                _lerpPosition[i] = Vector3.Lerp(_position[i], _targetPosition[i], lerpAmount);
            }
            _lineRenderer.SetPositions(_lerpPosition);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GenerateKoch(_targetPosition, true, generateMultiplier);
            _lerpPosition = new Vector3[_position.Length];
            _lineRenderer.positionCount = _position.Length;
            _lineRenderer.SetPositions(_position);
            lerpAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GenerateKoch(_targetPosition, false, generateMultiplier);
            _lerpPosition = new Vector3[_position.Length];
            _lineRenderer.positionCount = _position.Length;
            _lineRenderer.SetPositions(_position);
            lerpAmount = 0;
        }
    }
}
