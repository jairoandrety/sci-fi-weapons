using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Collider collider;
    public Rigidbody rb;
    public PowerEffect effect;
    public float speed;

    protected Vector3 direction;

    public void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    public void Init(PowerEffect effect, bool applyGravity, float speed)
    {
        Debug.Log($"entro aca: {effect != null}");
        this.effect = effect;
        this.speed = speed;
        collider.enabled = true;

        rb.useGravity = applyGravity;
        direction = transform.forward;
        rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        Hit();
    }

    public void Hit()
    {
        rb.isKinematic = true;
        effect = Instantiate(effect, transform.position, Quaternion.identity, null);
        effect.ApplyEffect();
        Destroy(gameObject);
    }
}