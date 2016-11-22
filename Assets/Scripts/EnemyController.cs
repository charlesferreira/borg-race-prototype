using UnityEngine;

public class EnemyController : MonoBehaviour {

    ShipMovement movement;
    
	void Awake() {
        movement = GetComponent<ShipMovement>();

        transform.rotation = Quaternion.Euler(
            Random.Range(0.0f, 360f),
            Random.Range(0.0f, 360f),
            Random.Range(0.0f, 360f));
    }
}
