using UnityEngine;
using System.Collections.Generic;

public class ShipWeapons : MonoBehaviour {

    public GameObject prefab;
    public List<Transform> spawnPoints;

	void Update () {
	    if (Input.GetButtonDown("Fire1")) {
            Fire();
        }
	}

    void Fire() {
        foreach (var spawn in spawnPoints) {
            Instantiate(prefab, spawn.position, spawn.rotation);
        }
    }
}
