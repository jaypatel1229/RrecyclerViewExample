
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using RecyclerViewEx.Resources.model;
using System;
using System.Collections.Generic;

namespace RecyclerViewEx.Resources.adapter
{
    internal class recyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<recyclerAdapterClickEventArgs> ItemClick;
        public event EventHandler<recyclerAdapterClickEventArgs> ItemLongClick;
        List<dataModel> items;
            Context context;

        public recyclerAdapter(List<dataModel> data, Context context )
        {
            items = data;
            this.context = context;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.newListItem;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new recyclerAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as recyclerAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.textviewone.Text = item.Name;
            holder.textviewtwo.Text = item.Description;
            holder.image.SetImageResource(item.Id);
        }

        public override int ItemCount => items.Count;

        void OnClick(recyclerAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(recyclerAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class recyclerAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView textviewone, textviewtwo;
        public ImageView image;

        public recyclerAdapterViewHolder(View itemView, Action<recyclerAdapterClickEventArgs> clickListener,
                            Action<recyclerAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            textviewone = itemView.FindViewById<TextView>(Resource.Id.textView);
            textviewtwo = itemView.FindViewById<TextView>(Resource.Id.textViewTwo);
            image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            itemView.Click += (sender, e) => clickListener(new recyclerAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new recyclerAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class recyclerAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}