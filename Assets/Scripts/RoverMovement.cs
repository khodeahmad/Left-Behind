using UnityEngine;
public class RoverMovement : MonoBehaviour
{
    public float speed = 35f;
    public float turnSpeed = 10f;
    Rigidbody rigidbody;
    Vector3 velocityHolder;

    [SerializeField] InputSystem inputSystem;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocityHolder = Vector3.zero;
    }


    void FixedUpdate()
    {

        Vector2 inputVector = inputSystem.GetMovementVectorNormalized();

        Vector3 movement = transform.forward * Input.GetAxis("Vertical") * speed;
        rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);

        float reverseMod = 1;
        if (inputVector.y < 0)
        {
            reverseMod = 0;
        }

        transform.Rotate(0, inputVector.x * turnSpeed * reverseMod, 0);

    }
}
