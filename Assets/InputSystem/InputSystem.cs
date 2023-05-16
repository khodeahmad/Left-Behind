using UnityEngine;

public class InputSystem : MonoBehaviour
{

    private LeftBehind playerInputActions;
    void Awake()
    {
        playerInputActions = new LeftBehind();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;

    }
}
