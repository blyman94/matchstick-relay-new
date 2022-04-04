using UnityEngine;

/// <summary>
/// Aggregates component movement vectors to calculate and apply final 
/// GameObject movement.
/// </summary>
public class MovementAggregator : MonoBehaviour
{
    /// <summary>
    /// CharacterController component used to move the attached GameObject.
    /// </summary>
    [Tooltip("CharacterController component used to move the attached " +
        "GameObject.")]
    [SerializeField] private CharacterController characterController;

    /// <summary>
    /// MovementComponent2Ds to aggregate.
    /// </summary>
    private IMovementComponent2D[] movementComponent2Ds;

    #region MonoBehaviour Methods
    private void Awake()
    {
        movementComponent2Ds = GetComponentsInChildren<IMovementComponent2D>();
    }
    private void LateUpdate()
    {
        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;
        foreach (IMovementComponent2D component in movementComponent2Ds)
        {
            horizontalMovement += component.HorizontalMovement;
            verticalMovement += component.VerticalMovement;
        }
        characterController.Move(new Vector3(horizontalMovement, 
            verticalMovement, 0.0f) * Time.deltaTime);
    }
    #endregion
}
