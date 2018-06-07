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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MVVM.Controls;
using MVVM.Droid.Library;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace MVVM.Droid.Library
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
        }
    }
}