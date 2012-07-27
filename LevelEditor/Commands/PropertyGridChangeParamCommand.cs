using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LevelEditor.Commands
{
    /// <summary>
    /// Команда на изменение свойства в PropertyGrid.
    /// По сути, значение свойства изменяет сам PropertyGrid, команда лишь обеспечивает механизм undo/redo.
    /// </summary>
    public class PropertyGridChangeParamCommand : IUndoRedoCommand
    {
        bool _redo = false;
        object _selectedObject;
        PropertyDescriptor _propertyDescriptor;
        object _oldValue;
        object _newValue;
        Action _callback;

        /// <param name="selectedObject">Выбранный в PropertyGrid объект.</param>
        /// <param name="propertyDescriptor">PropertyDescriptor для изменяемого свойства.</param>
        /// <param name="oldValue">Старое значение свойства.</param>
        /// <param name="newValue">Новое значение свойства.</param>
        /// <param name="callback">Метод обратного вызова, вызываемый при undo/redo команды.</param>
        public PropertyGridChangeParamCommand(object selectedObject, PropertyDescriptor propertyDescriptor, object oldValue, object newValue, Action callback)
        {
            _selectedObject = selectedObject;
            _propertyDescriptor = propertyDescriptor;
            _oldValue = oldValue;
            _newValue = newValue;
            _callback = callback;
        }

        public void Execute()
        {
            if (_redo)
            {
                _propertyDescriptor.SetValue(_selectedObject, _newValue);
                if (_callback != null)
                    _callback();
            }

            _redo = true;
        }

        public void Unexecute()
        {
            _propertyDescriptor.SetValue(_selectedObject, _oldValue);
            if (_callback != null)
                _callback();
        }

        public string Name
        {
            get { return "PropertyGridChangeParam"; }
        }
    }
}
