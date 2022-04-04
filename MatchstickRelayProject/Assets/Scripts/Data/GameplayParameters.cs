using UnityEngine;

/// <summary>
/// ScriptableObject that stores gameplay parameters.
/// </summary>
[CreateAssetMenu]
public class GameplayParameters : ScriptableObject
{
    /// <summary>
    /// How quickly is the GameObject pulled downward? Increases until
    /// maxFallVelocity is reached.
    /// </summary>
    [Header("Gravity")]
    [Header("Player Movement")]
    [Tooltip("How quickly is the GameObject pulled downward? Increases " +
        "until maxFallVelocity is reached.")]
    public float AppliedGravity = 9.8f;

    /// <summary>
    /// Max downward velocity at which the GameObject can travel.
    /// </summary>
    [Tooltip("Max downward velocity at which the GameObject can travel.")]
    public float MaxFallVelocity = 55.0f;

    /// <summary>
    /// Force at which this GameObject moves upward when it jumps.
    /// </summary>
    [Header("Jumping")]
    [Tooltip("Force at which this GameObject moves upward when it jumps.")]
    public float JumpForce = 5.5f;

    /// <summary>
    /// Can this GameObject jump again while in the air?
    /// </summary>
    [Tooltip("Can this GameObject jump again while in the air?")]
    public bool CanMultiJump = false;

    /// <summary>
    /// How many EXTRA jumps does the game object get while in the air?
    /// </summary>
    [Tooltip("How many EXTRA jumps does the game object get while in the air?")]
    public int MultiJumpLimit = 1;

    /// <summary>
    /// How fast the player moves when on the ground.
    /// </summary>
    [Header("Movement")]
    [Tooltip("How fast the player moves when on the ground.")]
    public float MoveSpeedGrounded = 1.0f;

    /// <summary>
    /// How fast the player moves when airborn.
    /// </summary>
    [Tooltip("How fast the player moves when airborn.")]
    public float MoveSpeedAirborn = 2.0f;
}
