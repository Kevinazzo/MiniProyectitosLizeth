using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Examen2
{
	class estadosListAdapter : BaseAdapter
	{
		Activity context;
		Dictionary<string, string> items;
		public estadosListAdapter(Activity _context, Dictionary<string, string> _db)
		{
			context = _context;
			items = _db;
		}

		public override int Count { get { return items.Count; } }

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return items.ToList().IndexOf(items.ElementAt(position));
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = context.LayoutInflater.Inflate(Resource.Layout.rowLayout, parent, false);
			TextView name = row.FindViewById<TextView>(Resource.Id.txt_nombreEstado);

			name.Text = items.ToList().ElementAt(position).Key;

			row.Click += delegate
			{
				Toast.MakeText(context,"la capital es "+ items.ToList().ElementAt(position).Value,ToastLength.Short).Show();
			};
			return row;
		}
	}
}