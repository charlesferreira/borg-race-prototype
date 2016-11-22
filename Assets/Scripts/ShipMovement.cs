using UnityEngine;

public class ShipMovement : MonoBehaviour {

    [Header("Steering")]
    public float rollIntensity = 10f;
    public float pitchIntensity = 30f;
    public float yawIntensity = 30f;

    [Header("Movement")]
    public float thrustPower = 500f;
    public float maxMovementSpeed = 10f;
    public float startingSpeed = 2f;

    float MaxMovementSpeedSqr { get { return maxMovementSpeed * maxMovementSpeed; } }
    
    Rigidbody rb;
    Vector3 roll;
    Vector3 pitch;
    Vector3 yaw;
    Vector3 thrust;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * startingSpeed;
    }

    void FixedUpdate() {
        Rotate();
        Move();
    }

    void LateUpdate() {
        if (rb.velocity.sqrMagnitude > MaxMovementSpeedSqr)
            rb.velocity = rb.velocity.normalized * maxMovementSpeed;
    }

    private void Rotate() {
        var torque = (roll + pitch + yaw) * Time.fixedDeltaTime;
        rb.AddTorque(torque);
    }

    private void Move() {
        rb.AddForce(thrust * Time.fixedDeltaTime);
    }

    public void Roll(float input) {
        roll = -input * rollIntensity * transform.forward;
    }

    public void Pitch(float input) {
        pitch = input * pitchIntensity * transform.right;
    }

    public void Yaw(float input) {
        yaw = input * yawIntensity * transform.up;
    }

    public void Thrust(float input) {
        thrust = input * thrustPower * transform.forward;
    }

}
