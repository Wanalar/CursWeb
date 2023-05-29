using CursLib.Models;
using CursWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursWPF.ViewModels
{
    public class EditBusVM :BaseTools 
    {
        public CommandVM SaveBus { get; set; }


        public Bus SelectedItem { get; set; }
        private List<Bus> bus;
        public Bus buses { get; set; }
        public string Number { get; set; }

        public List<Bus> Bus
        {
            get => bus;
            set
            {
                bus = value;

                Signal();
            }
        }

        public EditBusVM(Bus bus)
        {


            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Buses", "ListBuses", null);
                Bus = HttpApi.Deserialize<List<Bus>>(json);

               
            });


            SaveBus = new CommandVM(async () =>
            {
                try
                {
                    var json = await HttpApi.Post("Buses", "save", new Bus
                    {
                        Number = Number

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

        }
    }
}
