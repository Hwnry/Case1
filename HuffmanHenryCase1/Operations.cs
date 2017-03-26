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

namespace HuffmanHenryCase1
{
    [Activity(Label = "Operations")]
    public class Operations : Activity
    {
        TextView tvTest;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Title = "Operations";

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Operations);

            Button btnCRUD = (Button)FindViewById(Resource.Id.btnCRUD);
            btnCRUD.Click += BtnCRUD_Click;

            Button btnStatistics = (Button)FindViewById(Resource.Id.btnStatistics);
            btnStatistics.Click += BtnStatistics_Click;

            tvTest = (TextView)FindViewById(Resource.Id.tvTest);
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            
            tvTest.Text = "";
            tvTest.Text = MainActivity.numberOfEmployees.ToString();
        }

        private void BtnCRUD_Click(object sender, EventArgs e)
        {
            Intent toCRUD = new Intent(this, typeof(CRUD));
            StartActivityForResult(toCRUD, 0);
        }
    }

}

