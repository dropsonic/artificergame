using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace System.ComponentModel
{
    public partial class ListEditorForm<T> : Form
    {
        #region Поля и свойства
        private BindingList<T> _list;

        /// <summary>
        /// Список элементов для редактирования в форме.
        /// </summary>
        public IList<T> DataList
        {
            get 
            { 
                return _list.ToList<T>();
            }
            set 
            { 
                _list = new BindingList<T>(value);
                _list.ListChanged += new ListChangedEventHandler(_list_ListChanged);
                _list_ListChanged(_list, new ListChangedEventArgs(ListChangedType.ItemAdded, 0));
            }
        }

        void _list_ListChanged(object sender, ListChangedEventArgs e)
        {
            membersLabel.Text = String.Format("Members ({0} in total):", _list.Count);
        }

        /// <summary>
        /// Список выбранных пользователем элементов.
        /// </summary>
        public IList SelectedItems
        {
            get { return itemsListBox.SelectedItems; }
        }

        public string DisplayMember
        {
            get { return itemsListBox.DisplayMember; }
            set { itemsListBox.DisplayMember = value; }
        }

        #region Кнопки
        public Button AddButton { get { return addButton; } }
        public Button RemoveButton { get { return removeButton; } }
        public Button UpButton { get { return upButton; } }
        public Button DownButton { get { return downButton; } }
        public Button OKButton { get { return OKButton; } }
        public Button CancelButton { get { return cancelButton; } }
        #endregion
        #endregion

        #region Конструкторы
        public ListEditorForm(IList<T> dataList)
        {
            InitializeComponent();
            this.DataList = dataList;
            itemsListBox.DataSource = _list;
        }

        public ListEditorForm(IList<T> dataList, string text)
            : this(dataList)
        {
            this.Text = text;
        }

        public ListEditorForm(IList<T> dataList, string text, string displayMember)
            : this(dataList)
        {
            this.Text = text;
            itemsListBox.DisplayMember = displayMember;
        }
        #endregion

        #region События
        public event CancelEventHandler AddButtonClick;
        public event CancelEventHandler RemoveButtonClick;
        public event CancelEventHandler UpButtonClick;
        public event CancelEventHandler DownButtonClick;
        public event CancelEventHandler OKButtonClick;
        public event CancelEventHandler CancelButtonClick;

        protected virtual void OnAddButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (AddButtonClick != null)
                AddButtonClick(this, args);

            //Default behavior
            if (!args.Cancel)
            {
                //Получаем конструктор без параметров
                ConstructorInfo constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
                //Создаём объект
                T element = (T)constructor.Invoke(null);
                //Добавляем в список
                _list.Add(element);
            }
        }

        protected virtual void OnRemoveButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (RemoveButtonClick != null)
                RemoveButtonClick(this, args);

            if (!args.Cancel)
            {
                //Составляем список элементов на удаление
                T[] delElements = new T[SelectedItems.Count];
                for (int i = 0; i < SelectedItems.Count; i++)
                    delElements[i] = (T)SelectedItems[i];

                //Удаляем элементы
                foreach (T element in delElements)
                    _list.Remove(element);
            }
        }

        protected virtual void OnUpButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (UpButtonClick != null)
                UpButtonClick(this, args);

            if (!args.Cancel)
            {
                //Сохраняем индексы выбранных элементов
                int[] selected = new int[itemsListBox.SelectedIndices.Count];
                itemsListBox.SelectedIndices.CopyTo(selected, 0);

                bool moved = false;

                for (int k = 0; k < selected.Length; k++)
                {
                    int i = selected[k];
                    //Если элемент ещё не на верхушке
                    if ((i - 1) >= 0)
                    {
                        //то сдвигаем его вверх
                        SwapElements(_list, i, i - 1);
                        moved = true;
                    }
                    else
                        return;
                }

                //Если элементы были сдвинуты, то передвигаем выделение
                if (moved)
                {
                    for (int j = 0; j < selected.Length; j++)
                    {
                        itemsListBox.SetSelected(selected[j], false);
                        itemsListBox.SetSelected(selected[j] - 1, true);
                    }
                }
            }
        }

        protected virtual void OnDownButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (DownButtonClick != null)
                DownButtonClick(this, args);

            if (!args.Cancel)
            {
                //Сохраняем индексы выбранных элементов
                int[] selected = new int[itemsListBox.SelectedIndices.Count];
                itemsListBox.SelectedIndices.CopyTo(selected, 0);

                bool moved = false;

                for (int k = selected.Length - 1; k >= 0; k--)
                {
                    int i = selected[k];
                    //Если элемент ещё не на верхушке
                    if ((i + 1) < _list.Count)
                    {
                        //то сдвигаем его вверх
                        SwapElements(_list, i, i + 1);
                        moved = true;
                    }
                    else
                        return;
                }

                //Если элементы были сдвинуты, то передвигаем выделение
                if (moved)
                {
                    for (int j = selected.Length - 1; j >= 0; j--)
                    {
                        itemsListBox.SetSelected(selected[j], false);
                        itemsListBox.SetSelected(selected[j] + 1, true);
                    }
                }
            }
        }

        protected virtual void OnOKButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (OKButtonClick != null)
                OKButtonClick(this, args);

            if (!args.Cancel)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        protected virtual void OnCancelButtonClick()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (CancelButtonClick != null)
                CancelButtonClick(this, args);

            if (!args.Cancel)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
        #endregion

        private void SwapElements(IList list, int a, int b)
        {
            object temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        #region Обработчики событий элементов UI
        private void okButton_Click(object sender, EventArgs e)
        {
            OnOKButtonClick();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnCancelButtonClick();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OnAddButtonClick();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            OnRemoveButtonClick();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            OnUpButtonClick();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            OnDownButtonClick();
        }

        private void itemsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Указываем PropertyGrid'у, что надо редактировать выделенные объекты
            object[] selectedItems = new object[itemsListBox.SelectedItems.Count];
            if (selectedItems.Length == 0)
                propertyGrid.SelectedObject = null;
            else
            {
                for (int i = 0; i < itemsListBox.SelectedItems.Count; i++)
                    selectedItems[i] = itemsListBox.SelectedItems[i];
                //itemsListBox.SelectedItems.CopyTo(selectedItems, 0);
                propertyGrid.SelectedObjects = selectedItems;
            }

            //Обновляем текст
            if (selectedItems.Length == 0)
                propertiesLabel.Text = "Properties:";
            else if (selectedItems.Length > 1)
                propertiesLabel.Text = "Multi-Select Properties:";
            else
            {
                PropertyInfo property = typeof(T).GetProperty(DisplayMember);
                object value;
                if (property == null)
                {
                    FieldInfo field = typeof(T).GetField(DisplayMember);
                    if (field != null)
                        value = field.GetValue(selectedItems[0]);
                    else
                        value = selectedItems[0].ToString();
                }
                else
                    value = property.GetValue(selectedItems[0], null);

                propertiesLabel.Text = String.Format("{0} properties:", value);
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //Обновляем информацию в ListBox при изменениях в PropertyGrid
            _list.ResetBindings();
        }
        #endregion
    }
}
