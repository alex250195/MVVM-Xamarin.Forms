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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MVVM.Controls;
using MVVM.Droid.Library;

[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace MVVM.Droid.Library
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightCoral);
                Control.SetTextColor(global::Android.Graphics.Color.DarkBlue);
            }
        }
    }
}