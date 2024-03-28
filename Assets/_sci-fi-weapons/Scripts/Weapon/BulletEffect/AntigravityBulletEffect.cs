using System.Collections.Generic;
using UnityEngine;

public class AntigravityBulletEffect : PowerEffect
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
            foreach (var item in items)
            {
                Vector3 targetPos = new Vector3(item.transform.position.x, 20, item.transform.position.z);
                item.transform.position = Vector3.Lerp(item.transform.position, targetPos, Time.deltaTime * 0.25f);
                item.transform.Rotate(new Vector3(5,5,5) * speed * Time.deltaTime);
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