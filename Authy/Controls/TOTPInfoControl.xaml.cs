using Authy.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Authy.Controls
{
   

    public sealed partial class TOTPInfoControl : UserControl
    { 
        #region Properties
    
        private static readonly DependencyProperty TOTPProperty = DependencyProperty.Register(nameof(TOTP), typeof(TOTPModel), typeof(TOTPInfoControl), new PropertyMetadata(null));

        public TOTPModel TOTP 
        {
            get => (TOTPModel)GetValue(TOTPProperty); 
            set => SetValue(TOTPProperty, value); 
        }

        #endregion

        public TOTPInfoControl()
        {
            this.InitializeComponent();
            // TO-DO: Get the password.
        }
    }
}
