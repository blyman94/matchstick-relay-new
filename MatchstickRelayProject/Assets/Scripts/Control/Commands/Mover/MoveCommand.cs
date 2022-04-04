/// <summary>
/// Command that instructs the executing CommandRelay to move in a direction.
/// </summary>
public class MoveCommand : ICommand
{
    public float MoveInput { get; set; }
    public void Execute(CommandRelay commandRelay)
    {
        commandRelay.Mover.MoveInput = MoveInput;
        //commandRelay.Mover.Move();
    }
}
