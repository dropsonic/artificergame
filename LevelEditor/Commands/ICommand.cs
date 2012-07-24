namespace LevelEditor.Commands
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
        string Name { get; }
    }
}