using CursLib.Models;
using CursWPF.Tools;
using CursWPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursWPF.ViewModels
{
    public class ListBusesVM : BaseTools
    {
        public Bus SelectedItem { get; set; }
        private List<Bus> bus;
        public Bus buses { get; set; }
        public string Number { get; set; }
        public int Site { get; set; }
        public List<Bus> Bus
        {
            get => bus;
            set
            {
                bus = value;

                Signal();
            }
        }

        public CommandVM DeleteBus { get; set; }
        public CommandVM EditBus { get; set; }
        public CommandVM Save { get; set; }

        public ListBusesVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Buses", "ListBuses", null);
                Bus = HttpApi.Deserialize<List<Bus>>(json);
            });


            EditBus = new CommandVM(async () =>
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show("Ошибка");
                }
                else
                {
                    buses = SelectedItem;
                    new BusEdit(buses).Show();
                }
            });

            Save = new CommandVM(async () =>
            {
                try
                {
                    var json = await HttpApi.Post("Buses", "save", new Bus
                    {
                        Number = Number,
                        Site = Site
                    });
                    Bus result = HttpApi.Deserialize<Bus>(json);
                    if (Number != null)
                    {
                        { MessageBox.Show("Сохранилось!"); }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }

            });

            DeleteBus = new CommandVM(async () =>
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show("Ошибка");
                }
                else
                {
                    var json = await HttpApi.Post("Buses", "delete", SelectedItem.BusId);

                    Task.Run(async () =>
                    {
                        var json = await HttpApi.Post("Buses", "ListBuses", null);
                        Bus = HttpApi.Deserialize<List<Bus>>(json);
                    });
                }
            });
        }
    }
}
