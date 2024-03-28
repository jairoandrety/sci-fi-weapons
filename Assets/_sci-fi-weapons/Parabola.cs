using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    public float gravity = 9.81f;
    public float launchSpeed = 10f;
    public float maxTime = 5f;
    public float parabolaWidth = 10f;
    public Transform cameraTransform;

    public Vector3 velocity;
    public float t;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        velocity = launchSpeed * Vector3.up;
    }

    private void Update()
    {
        Vector3 position = transform.position + velocity * t + 0.5f * gravity * t * t * Vector3.down;
    }
}
