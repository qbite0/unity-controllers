using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Camera")]
    public FPSCamera Camera;

    [Header("Main")]
    public float Speed = 6f;
    public float Jump = 6f;

    [Header("Ground")]
    public bool IsGrounded;
    public LayerMask GroundMask;

    private CharacterController Controller;
    private Vector3 Movement = Vector3.zero;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, Controller.radius + Controller.skinWidth + 0.01f, GroundMask);

        Movement = new Vector3(Input.GetAxis("Horizontal") * Speed, Movement.y, Input.GetAxis("Vertical") * Speed);

        if (IsGrounded)
        {
            Movement.y = 0;

            if (Input.GetButton("Jump"))
                Movement.y = Jump;
        }

        if (Controller.collisionFlags == CollisionFlags.Above)
            Movement.y = -2f;

        Movement.y += Physics.gravity.y * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, Camera.Rotation.y, 0);

        Controller.Move(transform.TransformDirection(Movement) * Time.deltaTime);
    }
}