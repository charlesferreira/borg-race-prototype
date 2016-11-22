using UnityEngine;
using System.Collections.Generic;

public class ShipWeapons : MonoBehaviour {

    public Bullet prefab;
    public List<Transform> spawnPoints;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {
	    if (Input.GetButton("Fire1")) {
            Fire();
        }
	}

    void Fire() {
        foreach (var spawn in spawnPoints) {
            var bullet = (Bullet)Instantiate(prefab, spawn.position, spawn.rotation);
            bullet.Velocity = rb.velocity;
        }
    }
}
