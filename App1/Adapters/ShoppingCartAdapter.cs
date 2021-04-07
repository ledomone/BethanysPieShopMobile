using Android.Support.V7.Widget;
using Android.Views;
using BethanysPieShopMobile.Core.Repository;
using BethanysPieShopMobile.Utility;
using BethanysPieShopMobile.ViewHolders;
using System;

namespace BethanysPieShopMobile.Adapters
{
    public class ShoppingCartAdapter : RecyclerView.Adapter
    {
        private readonly ShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartAdapter()
        {
            _shoppingCartRepository = new ShoppingCartRepository();
            
        }
        public override int ItemCount => _shoppingCartRepository.GetAllShoppingCartItems().Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CartViewHolder cartViewHolder)
            {
                var cartItem = _shoppingCartRepository.GetAllShoppingCartItems()[position];
                cartViewHolder.PieNameTextView.Text = cartItem.Pie.Name;
                cartViewHolder.PieAmountTextView.Text = cartItem.Amount.ToString();

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(cartItem.Pie.ImageThumbnailUrl);
                cartViewHolder.PieImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cart_viewholder, parent, false);
            CartViewHolder cartViewHolder = new CartViewHolder(itemView, OnClick);
            return cartViewHolder;
        }

        private void OnClick(int obj)
        {
            //not needed here
        }
    }
}