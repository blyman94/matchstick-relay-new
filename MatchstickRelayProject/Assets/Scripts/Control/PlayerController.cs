using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Receives commands from the user and transmits them to the current controlled
/// object through a CommandStream.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// CommandStream that will recieve commands from the user.
    /// </summary>
    [Tooltip("CommandStream that will recieve commands from the user.")]
    [SerializeField] private CommandStream CommandStream;

    #region Commands
    private JumpCommand startJump = new JumpCommand();
    private MoveCommand move = new MoveCommand();
    #endregion

    #region Input Action Responses
    /// <summary>
    /// Responds to jump input by enqueueing a JumpCommand in the CommandStream.
    /// </summary>
    /// <param name="context">Callback context of the controlling input 
    /// action.</param>
    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CommandStream.Stream.Enqueue(startJump);
        }
    }

    /// <summary>
    /// Responds to movement input by enqueueing a MoveCommand in the 
    /// CommandStream.
    /// </summary>
    /// <param name="context">Callback context of the controlling input 
    /// action.</param>
    public void OnHorizontalMoveAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            move.MoveInput = context.ReadValue<float>();
            CommandStream.Stream.Enqueue(move);
        }
        else
        {
            move.MoveInput = 0.0f;
            CommandStream.Stream.Enqueue(move);
        }
    }
    #endregion

}
