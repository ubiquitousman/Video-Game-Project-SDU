using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    // From Test2.cs
    public float m_DampTime = 1f;                 // Approximate time for the camera to refocus.
    public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.

    private Camera m_Camera;                        // Used for referencing the camera.
    private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
 
    public string whichIsBigger = "";
    public float zoomFactor;

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;


    private Vector3 velocity;
    private Camera cam;

    public Vector3 startPosition;

    private void Start()
    {
        cam = GetComponent<Camera>();
        startPosition = this.transform.position;
        
    }

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


    void LateUpdate() // This will be executed after everyting else has
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();


    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
   
        // Find the required size based on the desired position and smoothly transition to that size.
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);

    }

    private float FindRequiredSize()
    {
    
      if (whichIsBigger == "x")
        {
            zoomFactor = 0.15f;
        }
        if (whichIsBigger == "y")
        {
            zoomFactor = 0.18f;
        }

        return (GetGreatestDistance() * zoomFactor+zoomFactor*33);
    }

    float GetGreatestDistance()
    {
        var Bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            Bounds.Encapsulate(targets[i].position);
        }
        if (Bounds.size.x> Bounds.size.y)
        {
            whichIsBigger = "x";
            return Bounds.size.x;

        } else
        {
            whichIsBigger = "y";
            return Bounds.size.y;
            
        }
        
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        if (whichIsBigger == "x")
        {
            offset.y = 0f;
        }

        else if (whichIsBigger == "y")
        {
            offset.y = -0.5f;
        }

        return bounds.center;

    }

}
