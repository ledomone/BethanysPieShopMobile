using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace BethanysPieShopMobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _orderButton;
        private Button _shoppingCartButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);

            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _orderButton.Click += _orderButton_Click;
            _shoppingCartButton.Click += _shoppingCartButton_Click;
        }

        private void _shoppingCartButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void _orderButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PieMenuActivity));
            StartActivity(intent);
        }

        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _shoppingCartButton = FindViewById<Button>(Resource.Id.shoppingCartButton);
        }
    }
}