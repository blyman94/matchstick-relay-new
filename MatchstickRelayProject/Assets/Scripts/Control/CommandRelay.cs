using UnityEngine;

/// <summary>
/// Contains references to all components used to control a GameObject. Executes 
/// commands from a CommandStream.
/// </summary>
public class CommandRelay : MonoBehaviour
{
    /// <summary>
    /// CommandStream from which this relay will execute commands.
    /// </summary>
    [Tooltip("CommandStream from which this relay will execute commands.")]
    [SerializeField] private CommandStream commandStream;

    /// <summary>
    /// Component that allows the GameObject to move on the X axis.
    /// </summary>
    [Tooltip("Component that allows the GameObject to move on the X axis.")]
    public Mover Mover;

    /// <summary>
    /// Component that allows the GameObject to jump.
    /// </summary>
    [Tooltip("Component that allows the GameObject to jump.")]
    public Jumper Jumper;

    #region MonoBehaviour Methods
    private void Update()
    {
        if (!System.Object.ReferenceEquals(commandStream,null) && 
            commandStream.Stream.Count > 0)
        {
            commandStream.Stream.Dequeue().Execute(this);
        }
    }
    #endregion
}
