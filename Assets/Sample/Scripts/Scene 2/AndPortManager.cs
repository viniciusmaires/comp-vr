using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndPortManager : MonoBehaviour
{
    [Range(3f, 15f)] public float speed = 3f;
    public Transform PointToMove;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = PointToMove.TransformPoint(new Vector3(0, 0, 0));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
