using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(F))]
public class FPPlayer : NetworkBehaviour
{
    [Header("Components")]
    [SerializeField] F FPController;

    #region Input Handling

    void OnMove(InputValue value)
    {
        FPController.MoveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        FPController.LookInput = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        FPController.SprintInput = value.isPressed;
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            FPController.TryJump();
        }
    }

    #endregion

    #region Unity Methods

    void OnValidate()
    {
        if (FPController == null) FPController = GetComponent<F>();    
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion
}
