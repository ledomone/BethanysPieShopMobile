using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace BethanysPieShopMobile.ViewHolders
{
    public class PieViewHolder : RecyclerView.ViewHolder
    {
        public ImageView PieImageView { get; set; }
        public TextView PieNameTextView { get; set; }
        public PieViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            PieImageView = itemView.FindViewById<ImageView>(Resource.Id.pieImageView);
            PieNameTextView = itemView.FindViewById<TextView>(Resource.Id.pieNameTextView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}