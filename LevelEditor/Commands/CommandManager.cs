using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class CommandManager
    {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        private List<ICommand> _executedCommandList = new List<ICommand>();
        private int _currentCommandIndex = -1;

        /// <summary>
        /// Добавляет команду в список команд.
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(ICommand command)
        {
            _commands.Add(command.Name,command); 
        }

        /// <summary>
        /// Выполняет указанную команду.
        /// </summary>
        /// <param name="command">Команда для выполнения.</param>
        /// <param name="redo">true, если команда вызывается как Redo; false в ином случае.</param>
        private void Execute(ICommand command, bool redo)
        {
            try
            {
                command.Execute();
                //Если это команда, поддерживающая механизм undo/redo, то добавляем её в список выполненных команд
                if (command is IUndoRedoCommand)
                {
                    if (redo)
                    {
                        _executedCommandList[_currentCommandIndex + 1] = command;
                    }
                    else
                    {
                        //Если мы в конце списка (нельзя сделать redo) - просто добавляем новую команду
                        if (!CanRedo)
                            _executedCommandList.Add(command);
                        else
                        {
                            //Иначе добавляем команду в текущее положение в списке, а все команды в списке после неё удаляем.
                            _executedCommandList[_currentCommandIndex + 1] = command;
                            int deleteIndex = _currentCommandIndex + 2;
                            int deleteCount = _executedCommandList.Count - deleteIndex;
                            _executedCommandList.RemoveRange(deleteIndex, deleteCount);
                        }
                    }

                    _currentCommandIndex++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Command {0} executed  incorrectly", command.Name), ex);
            }
        }

        /// <summary>
        /// Выполняет указанную команду.
        /// </summary>
        /// <param name="command">Команда для выполнения.</param>
        public void Execute(ICommand command)
        {
            Execute(command, false);
        }

        /// <summary>
        /// Выполняет команду с указанным именем из списка команд CommandManager'a.
        /// </summary>
        /// <param name="commandName">Имя команды.</param>
        public void Execute(string commandName)
        {
            try
            {
                ICommand command = _commands[commandName];
                Execute(command);
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException(String.Format("Command with name \"{0}\" not found.", commandName), ex);
            }
        }

        /// <summary>
        /// Отменяет предыдущую команду.
        /// </summary>
        public void Undo()
        {
            if (CanUndo)
            {
                IUndoRedoCommand command = (IUndoRedoCommand)_executedCommandList[_currentCommandIndex];
                try
                {
                    command.Unexecute();
                    _currentCommandIndex--;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Command {0} have not unexecuted", command.Name), ex);
                }
            }
        }

        /// <summary>
        /// Повторяет последнюю отменённую команду.
        /// </summary>
        public void Redo()
        {
            if (CanRedo)
                Execute(_executedCommandList[_currentCommandIndex+1], true);
        }

        public bool CanUndo
        {
            get { return _currentCommandIndex >= 0; }
        }

        public bool CanRedo
        {
            get { return _currentCommandIndex < _executedCommandList.Count - 1; }
        }
    }
}
