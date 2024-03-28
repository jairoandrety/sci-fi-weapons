using UnityEngine;
using System;

public class ParabolaDrawer : MonoBehaviour
{
    public int resolution = 10;
    public float maxAngle = 45f;
    public float maxHeight = 5f;
    public float maxDistance = 10f;
    public GameObject parabolaPointPrefab;

    private void Start()
    {
        DrawParabola();
    }

    [ContextMenu("DrawParabola")]
    public void DrawParabola()
    {
        float angle = Camera.main.transform.eulerAngles.x;
        float radianAngle = angle * Mathf.Deg2Rad;
        float normalizedAngle = Mathf.Clamp(angle, 0f, maxAngle) / maxAngle;

        float currentMaxHeight = maxHeight * normalizedAngle;
        float currentMaxDistance = maxDistance * normalizedAngle;

        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            float x = t * currentMaxDistance;
            float y = x * Mathf.Tan(radianAngle) - ((Physics.gravity.magnitude * x * x) / (2 * Mathf.Pow(currentMaxDistance * Mathf.Cos(radianAngle), 2)));
            Vector3 position = new Vector3(0f, y + currentMaxHeight, x);
            GameObject point = Instantiate(parabolaPointPrefab, position, Quaternion.identity);
            point.transform.SetParent(transform);
            point.transform.localPosition = position;
            point.transform.localScale = Vector3.one;
        }
    }
}
