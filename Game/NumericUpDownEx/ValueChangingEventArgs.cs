using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public delegate void ValueChangingEventHandler(object sender, ValueChangingEventArgs e);

    public class ValueChangingEventArgs : EventArgs
    {
        public decimal OldValue { get; private set; }
        public decimal NewValue { get; private set; }
        public bool KeepOldValue { get; set; }

        public ValueChangingEventArgs(decimal oldValue, decimal newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
            KeepOldValue = false;
        }
    }
}
