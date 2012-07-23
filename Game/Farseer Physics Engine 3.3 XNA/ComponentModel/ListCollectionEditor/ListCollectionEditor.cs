using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace System.ComponentModel
{
    public class ListCollectionEditor<T> : UITypeEditor
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
                    using (ListEditorForm<T> form = new ListEditorForm<T>((IList<T>)value))
                    {
                        if (svc.ShowDialog(form) == DialogResult.OK)
                        {
                            value = form.DataList;
                        }
                    }
                }
            }

            return base.EditValue(context, provider, value);
        }

        /// <summary>
        /// Возвращаем стиль редактора - модальное окно.
        /// </summary>
        public override UITypeEditorEditStyle GetEditStyle(
          ITypeDescriptorContext context)
        {
            if (context != null)
                return UITypeEditorEditStyle.Modal;
            else
                return base.GetEditStyle(context);
        }
    }
}
