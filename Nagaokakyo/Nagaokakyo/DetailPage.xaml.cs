using Kizu.Models;
using Kizu.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nagaokakyo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        private TableViewModel? viewModel;

        public DetailPage()
        {
            InitializeComponent();

            viewModel = App.Current.Services.GetService<TableViewModel>();
            ReturnBtn.Click += ReturnBtn_Click;
        }

        private async void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel != null)
            {
                await viewModel.SaveAsync();
            }
            Frame.Navigate(typeof(BalanceSheet));
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Table table && viewModel is TableViewModel)
            {
                await viewModel.InitializeForExisting(table);
            }
        }
    }
}
