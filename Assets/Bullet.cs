using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}
}
