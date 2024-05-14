using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] Archer _archer;
    [SerializeField] Transform _startPoint;

    private LineRenderer _lineRenderer;


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        InputHandler.instance.OnMouseLeftPressed += StartDrawLine;
        InputHandler.instance.OnMouseLeftRelease += StopDrawLine;
    }
    private void Update()
    {
        ShowTrajectory( _startPoint.position, _archer.GetRotationPosition());
    }


    private void ShowTrajectory(Vector3 startPosition, Vector3 velosity)
    {
        Vector3[] points = new Vector3[5];
        _lineRenderer.positionCount = points.Length;


        for (int i = 0; i < points.Length; i++)
        {
            float time = 0.05f + i * 0.2f;


            //The formula is used here
            // Vector3 pointPosition = startPosition + velosity * timePosition + Physics.gravity * timePosition * timePosition / 2f;
            points[i] = ProjectMath.GetPositiontTrajectory(time, startPosition, velosity);
        }
        _lineRenderer.SetPositions(points);
    }

    private void StartDrawLine()
    {
        _lineRenderer.enabled = true;
    }

    private void StopDrawLine()
    {
        _lineRenderer.enabled=false;
    }

}
