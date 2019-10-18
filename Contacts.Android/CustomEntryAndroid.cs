using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Content;
using Contacts;
using Contacts.Droid;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryAndroid))]
namespace Contacts.Droid
{
    public class CustomEntryAndroid : EntryRenderer
    {
        public CustomEntryAndroid(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            { 
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}
