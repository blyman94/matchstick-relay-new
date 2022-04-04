using UnityEngine;

/// <summary>
/// Allows the attached GameObject to move left and right.
/// </summary>
public class Mover : MonoBehaviour, IMovementComponent2D
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

    #region Properties
    /// <summary>
    /// Current move input for this GameObject.
    /// </summary>
    public float MoveInput { get; set; } = 0.0f;
    #endregion

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
    public void Update()
    {
        float finalSpeed = characterController.isGrounded ? 
            GameplayParameters.MoveSpeedGrounded :
            GameplayParameters.MoveSpeedAirborn;
        HorizontalMovement = (MoveInput * finalSpeed);
    }
    #endregion
}
