using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace System.Windows.Forms
{
    public class NumericUpDownEx : NumericUpDown
    {
        public event ValueChangingEventHandler ValueChanging;

        protected void OnValueChanging(ValueChangingEventArgs e)
        {
            if (ValueChanging != null)
                ValueChanging(this, e);
        }

        public override void UpButton()
        {
            decimal newValue = Value + Increment;
            var args = new ValueChangingEventArgs(Value, newValue);
            OnValueChanging(args);

            oldText = Text;
            base.UpButton();
            oldText = Text;

            if (args.KeepOldValue)
                Value = args.OldValue;

            oldValue = Value;
        }

        public override void DownButton()
        {
            decimal newValue = Value - Increment;
            var args = new ValueChangingEventArgs(Value, newValue);
            OnValueChanging(args);

            oldText = Text;
            base.DownButton();
            oldText = Text;

            if (args.KeepOldValue)
                Value = args.OldValue;

            oldValue = Value;
        }

        private ValueChangingEventArgs ParseText()
        {
            try
            {
                // VSWhidbey 173332: Verify that the user is not starting the string with a "-" 
                // before attempting to set the Value property since a "-" is a valid character with
                // which to start a string representing a negative number. 
                if (!string.IsNullOrEmpty(Text) &&
                    !(Text.Length == 1 && Text == "-"))
                {
                    Decimal newValue;

                    if (Hexadecimal)
                    {
                        newValue = Convert.ToDecimal(Convert.ToInt32(Text, 16));
                    }
                    else
                    {
                        newValue = Decimal.Parse(Text, CultureInfo.CurrentCulture);
                    }

                    if (!constraintsCorrection)
                    {
                        if ((newValue > Maximum) || (newValue < Minimum))
                        //if ((newValue != Maximum) && (newValue != Minimum))
                        {
                            constraintsCorrection = true;
                        }

                        var args = new ValueChangingEventArgs(oldValue, newValue);
                        OnValueChanging(args);

                        return args;
                    }
                }
            }
            catch
            {
                // Leave value as it is
            }

            return null;
        }

        private string oldText = String.Empty;
        private decimal oldValue;
        private bool constraintsCorrection = false;

        protected override void UpdateEditText()
        {
            if (oldText != Text)
            {
                oldText = Text;
                var args = ParseText();
                oldValue = Value;
                base.UpdateEditText();

                if (args != null)
                    if (args.KeepOldValue)
                    {
                        Value = args.OldValue;
                    }
            }
            else
                base.UpdateEditText();
        }

        protected override void InitLayout()
        {
            oldValue = Value;
            base.InitLayout();
        }
    }
}
