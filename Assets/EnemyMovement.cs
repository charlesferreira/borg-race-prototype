using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(
            Random.Range(0.0f, 360f),
            Random.Range(0.0f, 360f),
            Random.Range(0.0f, 360f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
