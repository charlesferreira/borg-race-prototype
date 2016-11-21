using UnityEngine;

public class ShipController : MonoBehaviour {

    const float RotationSensitivityMultiplier = 1000f;

    [Header("Rotation")]
    [Range(0.001f, 1f)]
    public float rotationSensitivity = 0.5f;
    [Range(0.001f, 1f)]
    public float rotationDamping = 0.5f;

    [Header("Movement")]
    public float thrustPower = 500f;
    public float strafePower = 200f;
    public float maxMovementSpeed = 10f;
    [Range(0, 1)]
    public float speedDamping = 0.001f;

    float MaxMovementSpeedSqr { get { return maxMovementSpeed * maxMovementSpeed; } }

    float LeftVert { get { return Input.GetKey("w") ? 1f : 0f; } }
    float LeftHorz { get { return Input.GetKey("d") ? 1f : Input.GetKey("a") ? -1f : 0f; } }

    float RightHorz { get { return Input.GetKey("right") ? 1f : Input.GetKey("left") ? -1f : 0f; } }
    float RightVert { get { return Input.GetKey("down") ? 1f : Input.GetKey("up") ? -1f : 0f; } }


    Rigidbody rb;
    Vector2 targetRotation;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Rotate();
    }

    void FixedUpdate() {
        Move();
    }

    void LateUpdate() {
        if (rb.velocity.sqrMagnitude > MaxMovementSpeedSqr)
            rb.velocity = rb.velocity.normalized * maxMovementSpeed;

        rb.velocity *= 1f - speedDamping;
    }

    private void Rotate() {
        var input = new Vector2(
            Input.GetAxis("Mouse Y"), 
            Input.GetAxis("Mouse X"));
        targetRotation += input;

        var partialRotation = targetRotation * rotationDamping;
        targetRotation -= partialRotation;

        var rotation = partialRotation * rotationSensitivity * RotationSensitivityMultiplier * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
    }

    private void Move() {
        var strafe = LeftHorz * strafePower * transform.right;
        var thrust = LeftVert * thrustPower * transform.forward;
        rb.AddForce((strafe + thrust) * Time.fixedDeltaTime);
    }
}
