using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject representation of a queue from which a CommandRelay will
/// execute commands.
/// </summary>
[CreateAssetMenu]
public class CommandStream : ScriptableObject
{
    /// <summary>
    /// Queue from which ICommands can be dequeued.
    /// </summary>
    public Queue<ICommand> Stream { get; set; } = new Queue<ICommand>();
}
