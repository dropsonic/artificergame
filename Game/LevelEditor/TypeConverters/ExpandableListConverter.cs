using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using FarseerTools;
using System.Windows.Forms;

namespace LevelEditor.TypeConverters
{
	internal class ExpandableListConverter<T> : System.ComponentModel.ExpandableObjectConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
			IList<T> list =  (IList<T>)value;
			foreach (T element in list)
			{
				ListDescriptor<T> desc = new ListDescriptor<T>(list.IndexOf(element), list);
				pds.Add(desc);
			}
			return pds;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return base.GetPropertiesSupported(context);
		}
	}

	internal class ListDescriptor<T> :PropertyDescriptor
	{
		private IList<T> _collection;
		private int _index = -1;

		public ListDescriptor(int index, IList<T> collection)
			: base("Desc", null)
		{
			_index = index;
			_collection = collection;
		} 

		public override AttributeCollection Attributes
		{
			get 
			{ 
				return new AttributeCollection(null);
			}
		}

		public override bool CanResetValue(object component)
		{
			return true;
		}

		public override Type ComponentType
		{
			get 
			{ 
				return _collection.GetType();
			}
		}

		public override string DisplayName
		{
			get 
			{
				return string.Format("[{0}]",_index);
			}
		}

		public override string Description
		{
			get
			{
				return string.Empty;
			}
		}

		public override object GetValue(object component)
		{
			return _collection[_index];
		}

		public override bool IsReadOnly
		{
			get { return false;  }
		}

		public override string Name
		{
			get { return "Name"; }
		}

		public override Type PropertyType
		{
			get { return _collection[_index].GetType(); }
		}

		public override void ResetValue(object component)
		{
		}

		public override bool ShouldSerializeValue(object component)
		{
			return true;
		}

		public override void SetValue(object component, object value)
		{

		}
	}
}
