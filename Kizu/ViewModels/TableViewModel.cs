using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kizu.Contexts;
using Kizu.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kizu.ViewModels
{
    public partial class TableViewModel : ObservableObject
    {
        private KizuContext context;
        private Table table;

        [ObservableProperty]
        private DateTimeOffset date;
        [ObservableProperty]
        private TimeSpan timeOfDay;
        [ObservableProperty]
        private string item;
        [ObservableProperty]
        private long cash;
        [ObservableProperty]
        private long icoca;
        [ObservableProperty]
        private long nanaco;
        [ObservableProperty]
        private long coop;

        public TableViewModel()
        {
            context = new();
            table = new();
            Date = table.DateTime.Date;
            TimeOfDay = table.DateTime.TimeOfDay;
            Item = table.Item;
            Cash = table.Cash;
            Icoca = table.Icoca;
            Nanaco = table.Nanaco;
            Coop = table.Coop;
        }


        public async Task InitializeForExisting(Table model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (await context.Tables.FindAsync(model.Id) is Table t)
                table = t;
            else
            {
                table = model;
                await context.Tables.AddAsync(table);
            }
            Date = table.DateTime.Date;
            TimeOfDay = table.DateTime.TimeOfDay;
            Item = table.Item;
            Cash = table.Cash;
            Icoca = table.Icoca;
            Nanaco = table.Nanaco;
            Coop = table.Coop;
        }

        [RelayCommand]
        public void Update()
        {
            DateTime dateTime = Date.Date;
            table.DateTime = dateTime.Add(TimeOfDay);
            table.Item = Item;
            table.Cash = Cash;
            table.Icoca = Icoca;
            table.Nanaco = Nanaco;
            table.Coop = Coop;
            context.Update(table);
        }

        [RelayCommand(CanExecute = nameof(IsTracked))]
        public void Delete()
        {
            context.Remove(table);
        }

        public bool IsTracked()
        {
            EntityEntry<Table> entry = context.Entry(table);
            if (entry == null)
                return false;
            else if (entry.State == EntityState.Deleted)
                return false;
            else if (entry.State == EntityState.Detached)
                return false;
            return true;
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
