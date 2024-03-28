using System.Collections.Generic;
using UnityEngine;

public class OrbitPowerEffect : PowerEffect
{
    [SerializeField] private float range = 1.0f;
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float speed = 1.0f;

    private List<GameObject> items = new List<GameObject>();    

    private bool initied = false;
    private float currentDuration = 0;

    public override void Init()
    {
        currentDuration = duration;
    }

    public override void ApplyEffect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Item")
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                items.Add(collider.gameObject);
            }
        }

        currentDuration = duration;
        initied = true;
    }

    void Update()
    {
        if (!initied)
            return;

        if (currentDuration > 0)
        {
            transform.Translate(Vector3.up * 0.1f * Time.deltaTime);

            foreach (var item in items)
            {
                item.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
                item.transform.position = Vector3.Lerp(item.transform.position, transform.position, Time.deltaTime * 0.2f);
            }
        
            currentDuration -= 1 * Time.deltaTime;
        }
        else
        {
            foreach (var item in items)
            {
                Rigidbody rb = item.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }

            initied = false;
            Destroy(gameObject);
        }
    }
}
