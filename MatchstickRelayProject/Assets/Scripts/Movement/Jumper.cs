using UnityEngine;

/// <summary>
/// Allows the attached GameObject to jump.
/// </summary>
public class Jumper : MonoBehaviour, IMovementComponent2D
{
    /// <summary>
    /// CharacterController component used to move the attached GameObject.
    /// </summary>
    [Tooltip("CharacterController component used to move the attached " +
        "GameObject.")]
    [SerializeField] private CharacterController characterController;
    
    /// <summary>
    /// Contains data that changes the behaviour of this component.
    /// </summary>
    [Tooltip("Contains data that changes the behaviour of this component.")]
    [SerializeField] private GameplayParameters gameplayParameters;

    /// <summary>
    /// How many times this GameObject has jumped while in the air.
    /// </summary>
    protected int multiJumpCount = 0;

    #region IMovementComponent2D Methods
    public GameplayParameters GameplayParameters
    {
        get
        {
            return gameplayParameters;
        }
        set
        {
            gameplayParameters = value;
        }
    }
    public float HorizontalMovement { get; set; }
    public float VerticalMovement { get; set; }
    #endregion

    #region MonoBehaviour Methods
    private void Update()
    {
        ApplyGravity();
    }
    #endregion

    /// <summary>
    /// Triggers the GameObject to jump.
    /// </summary>
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            VerticalMovement = GameplayParameters.JumpForce;
            multiJumpCount = 0;
        }
        else if (GameplayParameters.CanMultiJump && 
            (multiJumpCount < GameplayParameters.MultiJumpLimit))
        {
            VerticalMovement = GameplayParameters.JumpForce;
            multiJumpCount++;
        }
    }

    /// <summary>
    /// Applies a downward force to simulate falling.
    /// </summary>
    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            VerticalMovement -= 
                GameplayParameters.AppliedGravity * Time.deltaTime;
        }
        else
        {
            VerticalMovement = -0.5f;
        }

        if (VerticalMovement < -GameplayParameters.MaxFallVelocity)
        {
            VerticalMovement = -GameplayParameters.MaxFallVelocity;
        }
    }
}
