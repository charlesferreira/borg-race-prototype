using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 15f;
    public float lifeTime = 10f;

    Rigidbody rb;

    public Vector3 Velocity {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        rb.velocity += transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
