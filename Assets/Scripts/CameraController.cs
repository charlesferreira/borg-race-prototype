using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var speed = this.speed;
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            speed *= 5f;

        var horz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Rotate(Vector3.up, horz, Space.Self);
        transform.Rotate(Vector3.right, vert, Space.Self);
    }
}
