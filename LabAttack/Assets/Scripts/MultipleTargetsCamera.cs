using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetsCamera : MonoBehaviour
{
    public Transform[] targets;
    public float padding = 15f; // amount to pad in world units from screen edge

    Camera _camera;
    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate() // using LateUpdate() to ensure camera moves after everything else has
    {
        Bounds bounds = FindBounds();

        // Calculate distance to keep bounds visible. Calculations from:
        //     "The Size of the Frustum at a Given Distance from the Camera": https://docs.unity3d.com/Manual/FrustumSizeAtDistance.html
        //     note: Camera.fieldOfView is the *vertical* field of view: https://docs.unity3d.com/ScriptReference/Camera-fieldOfView.html
        float desiredFrustumWidth = bounds.size.x + 2 * padding;
        float desiredFrustumHeight = bounds.size.z + 2 * padding;

        float distanceToFitHeight = desiredFrustumHeight * 0.5f / Mathf.Tan(_camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float distanceToFitWidth = desiredFrustumWidth * 0.5f / Mathf.Tan(_camera.fieldOfView * _camera.aspect * 0.5f * Mathf.Deg2Rad);

        float resultDistance = Mathf.Max(distanceToFitWidth, distanceToFitHeight);

        // Set camera to center of bounds at exact distance to ensure targets are visible and padded from edge of screen 
        _camera.transform.position = bounds.center + Vector3.up * resultDistance;
    }

    private Bounds FindBounds()
    {
        if (targets.Length == 0)
        {
            return new Bounds();
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform target in targets)
        {
            if (target.gameObject.activeSelf) // if target not active
            {
                bounds.Encapsulate(target.position);
            }
        }

        return bounds;
    }
}
