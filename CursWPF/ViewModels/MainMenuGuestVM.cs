using CursLib.Models;
using CursWPF.Pages;
using CursWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace CursWPF.ViewModels
{
    public class MainMenuGuestVM : BaseTools
    {

        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
        public string BusStop { get; set; }
        public string DepartureTime { get; set; } 
        public string ArivalTime { get; set; }
        public int Cost { get; set; }

        private Bus buses;
        public Bus SelectedBus
        {
            get => buses;
            set
            {
                buses = value;
                Signal();
            }
        }

        public Trip SelectedItem { get; set; }

        private List<Bus> bus;
        private List<Trip> trips;
        public Trip trip { get; set; }


        public List<Trip> Trip
        {
            get => trips;
            set
            {
                trips = value;

                Signal();
            }
        }

        public List<Bus> Bus
        {
            get => bus;
            set
            {
                bus = value;

                Signal();
            }
        }

        public CommandVM EditTrip { get; set; }

        public CommandVM Save { get; set; }

        public CommandVM DeleteTrip { get; set; }
        
        public CommandVM nav_busesEmploy { get; set; }

        public CommandVM nav_usersEmploy { get; set; }

        public CommandVM nav_ticketsEmploy { get; set; }
        public CommandVM nav_tickets { get; set; }

        public CommandVM nav_infosEmploy { get; set; }
        
        public User User { get; set; } 

        public MainMenuGuestVM(User user)
        {
            User = user;

            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Trips", "ListTrips", null);
                Trip = HttpApi.Deserialize<List<Trip>>(json);

                var json2 = await HttpApi.Post("Buses", "ListBuses", null);
                Bus = HttpApi.Deserialize<List<Bus>>(json2);


            });
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            Save = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Trips", "save", new Trip
                {
                    BusStop = BusStop,
                    ArivalTime = ArivalTime,
                    DepartureTime = DepartureTime,
                    Bus = SelectedBus.BusId,
                    Cost = Cost
                });
                Trip result = HttpApi.Deserialize<Trip>(json);

                MessageBox.Show("Сохранилось");
            });

            DeleteTrip = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Trips", "delete", SelectedItem.TripId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Flights", "ListFlights", null);
                    Trip = HttpApi.Deserialize<List<Trip>>(json);

                    var json2 = await HttpApi.Post("Buses", "ListAirplanes", null);
                    Bus = HttpApi.Deserialize<List<Bus>>(json2);

                    
                });
            });

            nav_busesEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListBusesEmploy());
            });

            nav_ticketsEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListTicketsEmploy(User));
            });

            nav_usersEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListUsersEmploy());
            }); 

            nav_infosEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListInfoEmploy());
            });

            nav_tickets = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListTickets(User));
            });


        }

        

    }
}
