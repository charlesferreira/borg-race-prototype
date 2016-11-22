using UnityEngine;

public class ShipController : MonoBehaviour {

    ShipMovement movement;
    
	void Start () {
        movement = GetComponent<ShipMovement>();
	}
	
	void Update () {
        movement.Thrust(Mathf.Max(0f, Input.GetAxis("Vertical")));
        movement.Roll(Input.GetAxis("Horizontal"));
        movement.Pitch(Input.GetAxis("Mouse Y"));
        movement.Yaw(Input.GetAxis("Mouse X"));
    }
}
