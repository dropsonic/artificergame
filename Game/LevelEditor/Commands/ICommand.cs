namespace LevelEditor.Commands
{
    public interface ICommand
    {
        void Execute();
        string Name { get; }
    }

    /// <summary>
    /// Интерфейс команды, поддерживаемой механизмом undo/redo.
    /// </summary>
    public interface IUndoRedoCommand : ICommand
    {
        void Unexecute();
    }
}