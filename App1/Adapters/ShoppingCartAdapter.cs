using Android.Support.V7.Widget;
using Android.Views;
using BethanysPieShopMobile.Core.Repository;
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
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}