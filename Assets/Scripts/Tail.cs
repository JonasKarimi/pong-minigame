using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] int length;
    public LineRenderer lineRenderer;
    public Vector3[] pointPoss;
    private Vector3[] pointV;
    public float smoothSpeed;

    public Transform target;
    private void Start()
    {
        lineRenderer.positionCount = length;
         pointPoss = new Vector3[length];
        pointV = new Vector3[length];
    }
    private void Update()
    {
        pointPoss[0] = target.position;
        for (int i = 1; i < pointPoss.Length; i++) 
        {
            pointPoss[i] = Vector3.SmoothDamp(pointPoss[i], pointPoss[i - 1], ref pointV[i], smoothSpeed);
        }
        lineRenderer.SetPositions(pointPoss);
    }
}
