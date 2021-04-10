using CoreGraphics;
using Foundation;
using Projet_Xamarin.iOS.Renderers;
using Projet_Xamarin.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Projet_Xamarin.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        // On cree le Renderer IOS pour l'element CustomEntry
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Layer.CornerRadius = 20;
                Control.Layer.BorderWidth = 2f;
                Control.Layer.BorderColor = Color.Black.ToCGColor();
                Control.Layer.BackgroundColor = Color.LightGray.ToCGColor();
                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10,
                0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }
    }
}