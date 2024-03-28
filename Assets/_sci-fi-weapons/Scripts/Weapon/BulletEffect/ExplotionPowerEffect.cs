using System.Collections.Generic;
using UnityEngine;

public class ExplotionPowerEffect : PowerEffect
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
                    Vector3 direction = collider.gameObject.transform.position - transform.position;
                    float distance = Vector3.Distance(collider.gameObject.transform.position, transform.position);
                    float resutl = range -distance;
                    rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
                }
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
            currentDuration -= 1 * Time.deltaTime;
        }
        else
        {      
            initied = false;
            Destroy(gameObject);
        }
    }
}