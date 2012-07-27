using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FarseerPhysics.Dynamics;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace FarseerPhysics
{
    internal class FixtureListCollectionEditor : ListCollectionEditor<Fixture>
    {
        /// <summary>
        /// Реализация метода редактирования.
        /// </summary>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (svc != null)
                {
                    using (ListEditorForm<Fixture> form = new ListEditorForm<Fixture>((IList<Fixture>)value))
                    {
                        form.AddButton.Enabled = false;
                        if (svc.ShowDialog(form) == DialogResult.OK)
                        {
                            value = form.DataList;
                        }
                    }
                }
            }

            return value;
            //return base.EditValue(context, provider, value);
        }
    }
}
