namespace LevelEditor.Commands
{
    public interface ICommand
    {
        void Execute();
        string Name { get; }
    }

    /// <summary>
    /// ��������� �������, �������������� ���������� undo/redo.
    /// </summary>
    public interface IUndoRedoCommand : ICommand
    {
        void Unexecute();
    }
}