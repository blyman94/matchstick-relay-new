using UnityEngine;

/// <summary>
/// OnTriggerEnter, teleports the object to a specified position.
/// </summary>
public class TeleportToPosition : MonoBehaviour
{
    /// <summary>
    /// Position to which intersecting GameObjects will be teleported.
    /// </summary>
    [SerializeField] private Vector3 targetPosition;

    #region MonoBehaviour Methods
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = targetPosition;
    }
    #endregion
}
