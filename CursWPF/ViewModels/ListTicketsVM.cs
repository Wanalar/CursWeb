using CursLib.Models;
using CursWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CursWPF.ViewModels
{
    public class ListTicketsVM : BaseTools
    {
        public Ticket SelectedItem { get; set; }
        private List<Ticket> ticket;
        private List<User> user;
        private List<Trip> trip;
        private User users;
        private Trip trips;
        public Ticket tickets { get; set; }
   
        public string Title { get; set; }
        public string FirstName { get; set; }



        public List<Ticket> Ticket
        {
            get => ticket;
            set
            {
                ticket = value;

                Signal();
            }
        }

        public List<User> User
        {
            get => user;
            set
            {
                user = value;

                Signal();
            }
        }

        public List<Trip> Trip
        {
            get => trip;
            set
            {
                trip = value;

                Signal();
            }
        }

        public CommandVM DeleteTicket { get; set; }
        public CommandVM Save { get; set; }


        public ListTicketsVM(User user)
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Tickets", "ListTickets", null);
                Ticket = HttpApi.Deserialize<List<Ticket>>(json);

                var json2 = await HttpApi.Post("Users", "ListUsers", null);
                User = HttpApi.Deserialize<List<User>>(json2);

                var json3 = await HttpApi.Post("Trips", "ListTrips", null);
                Trip = HttpApi.Deserialize<List<Trip>>(json3);
            });


            //EditAirplane = new CommandVM(async () =>
            // {
            //   if (SelectedItem == null)
            //   {
            //    MessageBox.Show("Ошибка");
            //   }
            //  else
            //   {
            //       airplanes = SelectedItem;
            // new AirplaneEdit(airplanes).Show();
            //    }
            // });

            // Save = new CommandVM(async () =>
            // {
            //     try
            //  {
            // var json = await HttpApi.Post("Airplanes", "save", new Airplane
            //  {
            //  AirplaneTitle = Title,
            // Places = Seats,
            // ClassId = SelectedClass.AirplaneClassId
            //});
            //Airplane result = HttpApi.Deserialize<Airplane>(json);
            //if (Seats != null || SelectedClass != null || Title != null)
            // {
            //{ MessageBox.Show("Сохранилось!"); }
            // }
            //  }
            //  catch
            // {
            //MessageBox.Show("Ошибка");
            // }

            // });

            //  DeleteAirplane = new CommandVM(async () =>
            // {
            // if (SelectedItem == null)
            //     {
            // MessageBox.Show("Ошибка");
            //  }
            //  else
            // {
            // var json = await HttpApi.Post("Airplanes", "delete", SelectedItem.AirplanesId);

            // Task.Run(async () =>
            // {
            //  var json = await HttpApi.Post("Airplanes", "ListAirplanes", null);
            //Airplane = HttpApi.Deserialize<List<Airplane>>(json);

            // var json2 = await HttpApi.Post("AirplanesClasses", "ListAirplanesClasses", null);
            //AirplanesClass = HttpApi.Deserialize<List<AirplanesClass>>(json);
            //});
            //}
            //});

        }
    }
}
