using Android.App;
using Android.OS;
using Android.Widget;
using BethanysPieShopMobile.Core.Model;
using BethanysPieShopMobile.Core.Repository;
using BethanysPieShopMobile.Utility;

namespace BethanysPieShopMobile
{
    [Activity(Label = "PieDetailActivity")]
    public class PieDetailActivity : Activity
    {
        private PieRepository _pieRepository;
        private Pie _selectedPie;
        private ImageView _pieImageView;
        private TextView _pieNameTextView;
        private TextView _descriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _addToCartButton;
        private TextView _shortDescriptionTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pie_detail);
            // Create your application here
            _pieRepository = new PieRepository();
            var selectedPieId = Intent.Extras.GetInt("selectedPieId");
            _selectedPie = _pieRepository.GetPieById(selectedPieId);
            FindViews();
            BindData();
            LinkEventHandlers();
        }

        private void BindData()
        {
            _pieNameTextView.Text = _selectedPie.Name;
            _shortDescriptionTextView.Text = _selectedPie.ShortDescription;
            _descriptionTextView.Text = _selectedPie.LongDescription;
            _priceTextView.Text = "Price: " + _selectedPie.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_selectedPie.ImageUrl);
            _pieImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            _pieImageView = FindViewById<ImageView>(Resource.Id.pieImageView);
            _pieNameTextView = FindViewById<TextView>(Resource.Id.pieNameTextView);
            _shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            _addToCartButton = FindViewById<Button>(Resource.Id.addToCartButton);
        }

        private void LinkEventHandlers()
        {
            _addToCartButton.Click += _addToCartButton_Click;
        }

        private void _addToCartButton_Click(object sender, System.EventArgs e)
        {
            var amount = int.Parse(_amountEditText.Text);

            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            shoppingCartRepository.AddToShoppingCart(_selectedPie, amount);
            Toast.MakeText(Application.Context, "Pie added to cart", ToastLength.Long).Show();

            this.Finish();
        }
    }
}