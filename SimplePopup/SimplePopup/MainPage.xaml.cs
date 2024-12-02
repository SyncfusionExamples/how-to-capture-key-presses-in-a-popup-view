#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
#endif
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.Popup;
using System.Collections;
using System.Reflection;

namespace SimplePopup
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void popup_Closed(object sender, EventArgs e)
        {
            this.grid.Focus();
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            this.popup.IsOpen = true;
        }
    }

    public class CustomGrid : Grid, IKeyboardListener
    {
        public SfPopup Popup { get; set; }
        public CustomGrid()
        {
            this.AddKeyboardListener(this);
            this.Loaded += CustomGrid_Loaded;
           
        }

        private void CustomGrid_Loaded(object? sender, EventArgs e)
        {
            SetUpKeyListenerRequirements();
            this.Focus();
        }

        public void OnKeyDown(KeyEventArgs args)
        {
            if(this.Popup != null && !this.Popup.IsOpen && args.Key == KeyboardKey.O)
            {
                this.Popup.IsOpen=true;
            }
            if(this.Popup != null && this.Popup.IsOpen && args.Key == KeyboardKey.Enter)
            {
                this.Popup.IsOpen = false;
            }
        }

        public void OnKeyUp(KeyEventArgs args)
        {
            
        }

        private void SetUpKeyListenerRequirements()
        {
#if WINDOWS
            if (this.Handler != null)
            {
                (this.Handler.PlatformView as Microsoft.UI.Xaml.FrameworkElement)!.IsTabStop = true;
            }
#elif ANDROID
            if (this.Handler != null)
            {
                (this.Handler!.PlatformView as Android.Views.View) !.FocusableInTouchMode = true;
            }
#endif
        }
    }

}
