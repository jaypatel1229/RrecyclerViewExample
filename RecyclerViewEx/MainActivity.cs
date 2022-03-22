using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using RecyclerViewEx.Resources.adapter;
using RecyclerViewEx.Resources.model;
using System;
using System.Collections.Generic;

namespace RecyclerViewEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<dataModel> list;
        RecyclerView myRecyclerView;
        recyclerAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            addingData();
            adapter = new recyclerAdapter(list, this);
            myRecyclerView.SetAdapter(adapter);
            myRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            adapter.ItemClick += Adapter_ItemClick;
        }

        private void Adapter_ItemClick(object sender, recyclerAdapterClickEventArgs e)
        {
            Toast.MakeText(this, $"This is {list[e.Position].Name}",ToastLength.Short).Show();
        }

        private void addingData()
        {
          list = new List<dataModel>
          {
              new dataModel{Name = "Jay", Description = "Engineering", Id = Resource.Drawable.INA},
              new dataModel{Name = "Sagar", Description = "Engineering", Id = Resource.Drawable.ISRO},
              new dataModel{Name = "Priyank", Description = "Engineering", Id = Resource.Drawable.plane},
              new dataModel{Name = "Manish", Description = "Engineering", Id = Resource.Drawable.space},
              new dataModel{Name = "Mit", Description = "Engineering", Id = Resource.Drawable.Udan},
              new dataModel{Name = "Hinal", Description = "Engineering", Id = Resource.Drawable.VC1}
          };
        }
    }
}