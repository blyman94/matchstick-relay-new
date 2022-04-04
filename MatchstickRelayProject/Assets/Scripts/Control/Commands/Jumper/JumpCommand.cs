/// <summary>
/// Command that instructs the executing CommandRelay to jump.
/// </summary>
public class JumpCommand : ICommand
{
    public void Execute(CommandRelay commandRelay)
    {
        commandRelay.Jumper.Jump();
    }
}
