using Kizu.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
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
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Kizu.Models;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nagaokakyo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BalanceSheet : Page
    {
        private TablesViewModel? tables;

        public BalanceSheet()
        {
            InitializeComponent();
            tables = App.Current.Services.GetService<TablesViewModel>();

            DetailBtn.Click += DetailBtn_Click;
            SuperTable.SelectionChanged += SuperTable_SelectionChanged;
            Debug.WriteLine(System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Kizu.db"));
        }

        private void SuperTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuperTable.SelectedItem is Table)
            {
                DetailBtn.IsEnabled = true;
            }
        }

        private void DetailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SuperTable.SelectedItem is Table table)
            {
                Frame.Navigate(typeof(DetailPage), table);
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (tables == null)
                return;

            await tables.LoadAsync();
        }
    }
}
