using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace BethanysPieShopMobile
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private Button _phoneButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.about);

            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _phoneButton.Click += _phoneButton_Click;
        }

        private void FindViews()
        {
            _phoneButton = FindViewById<Button>(Resource.Id.phoneButton);
        }

        private void _phoneButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse("tel:+48334978300"));
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }
    }
}