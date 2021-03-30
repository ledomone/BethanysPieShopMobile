using Android.Support.V7.Widget;
using Android.Views;
using BethanysPieShopMobile.Core.Model;
using BethanysPieShopMobile.Core.Repository;
using BethanysPieShopMobile.Utility;
using BethanysPieShopMobile.ViewHolders;
using System.Collections.Generic;

namespace BethanysPieShopMobile.Adapters
{
    public class PieAdapter : RecyclerView.Adapter
    {
        private List<Pie> _pies;

        public PieAdapter()
        {
            var pieRepository = new PieRepository();
            _pies = pieRepository.GetAllPies();
        }
        public override int ItemCount => _pies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is PieViewHolder pieViewHolder)
            {
                pieViewHolder.PieNameTextView.Text = _pies[position].Name;

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_pies[position].ImageUrl);
                pieViewHolder.PieImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.pie_viewholder, parent, false);
            PieViewHolder pieViewHolder = new PieViewHolder(itemView);
            return pieViewHolder;
        }
    }
}