/// <summary>
/// Describes a component that can contribute to the overall motion of a
/// GameObject.
/// </summary>
public interface IMovementComponent2D
{
    /// <summary>
    /// Contains data that directly changes the behaviour of this component.
    /// </summary>
    GameplayParameters GameplayParameters { get; set; }

    /// <summary>
    /// Horizontal component of GameObject movement.
    /// </summary>
    float HorizontalMovement { get; set; }

    /// <summary>
    /// Vertical component of GameObject movement.
    /// </summary>
    float VerticalMovement { get; set; }
}
