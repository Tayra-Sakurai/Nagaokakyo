using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kizu.Contexts;
using Kizu.Models;

namespace Kizu.ViewModels
{
    public partial class TablesViewModel : ObservableObject
    {
        private KizuContext2 context;

        [ObservableProperty]
        private ObservableCollection<Table> tables;

        public TablesViewModel()
        {
            context = new();
            Tables = [];
        }

        [RelayCommand]
        public async Task LoadAsync()
        {
            Tables.Clear();
            await foreach (var item in context.Tables.AsAsyncEnumerable())
            {
                Tables.Add(item);
            }
        }

        [RelayCommand]
        public async Task AddAsync()
        {
            Table table = new();
            await context.Tables.AddAsync(table);
            await context.SaveChangesAsync();
            await LoadAsync();
        }
    }
}
