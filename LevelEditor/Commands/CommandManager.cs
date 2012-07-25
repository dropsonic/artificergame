using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    class CommandManager
    {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        private List<ICommand> _executedCommandList = new List<ICommand>();
        private int _currentCommandIndex = 0;

        public void AddCommand(ICommand command)
        {
            _commands.Add(command.Name,command); 
        }

        public void Execute(ICommand command)
        {
            if (!_commands.ContainsKey(command.Name))
                AddCommand(command);
            else
                Execute(command.Name);
        }

        public void Execute(string commandName)
        {
            try
            {
                ICommand command = _commands[commandName];
                command.Execute();
                //Если мы в конце списка (Redo не делалось)
                if (_currentCommandIndex == _executedCommandList.Count - 1)
                    _executedCommandList.Add(command);
                else
                    _executedCommandList[_currentCommandIndex] = command;

                _currentCommandIndex++;
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException(String.Format("Command with name \"{0}\" not found.", commandName), ex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Command {0} executed  incorrectly", commandName), ex);
            }
        }

        public void Undo()
        {
            if (CanUndo)
            {
                ICommand command = _executedCommandList[_currentCommandIndex];
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

        public void Redo()
        {
            if (CanRedo)
                Execute(_executedCommandList[_currentCommandIndex+1]);
        }

        public bool CanUndo
        {
            get { return _currentCommandIndex > 0; }
        }

        public bool CanRedo
        {
            get { return _currentCommandIndex < _executedCommandList.Count - 1; }
        }
    }
}
