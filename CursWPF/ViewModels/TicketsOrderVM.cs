using CursLib.Models;
using CursWeb;
using CursWPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursWPF.ViewModels
{
    public class TicketsOrderVM : BaseTools
    {
        private Trip selectedTrip;
        private Trip trip;

        public User User { get; set; }
        public Ticket Ticket { get; set; }
        public Bus Bus { get; set; }
        public int Busid { get; set; }
        public decimal EntryCost { get; set; }
        public Trip Trip 
        { 
            get => trip;
            set
            {
                trip = value;
                Signal();
            }
        }

        public Trip SelectedTrip
        {
            get => selectedTrip;
            set
            {
                selectedTrip = value;
                Signal();
            }
        }

        public TicketsOrderVM(User user)
        {
            User = user;
            Trips = Avto_VakzalContext.GetInstance().Trips.ToList();
            Cost = new CommandVM(() =>
            {
                Trip = Avto_VakzalContext.GetInstance().Trips.FirstOrDefault(s => s.TripId == SelectedTrip.TripId);
            });
            Save = new CommandVM(() =>
            {


                if (SelectedTrip != null)
                {
                    if (EntryCost >= Trip.Cost)
                    {
                        Bus = Avto_VakzalContext.GetInstance().Buses.FirstOrDefault(s => s.BusId == SelectedTrip.Bus);
                        if (Bus.Site != 0)
                        {
                            Ticket = new Ticket() { Iduser = User.UserId, Trip = SelectedTrip.TripId };
                            Avto_VakzalContext.GetInstance().Tickets.Add(Ticket);
                            Avto_VakzalContext.GetInstance().SaveChanges();
                            Bus.Site = Bus.Site - 1;
                            Avto_VakzalContext.GetInstance().Buses.Update(Bus);
                            Avto_VakzalContext.GetInstance().SaveChanges();
                            MessageBox.Show("Билет успешно куплен");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Мест нет, пока оформить невозможно");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств");
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ошибка, выберите маршрут");
                    return;
                }
            });

            
        }
        public List<Trip> Trips { get; set; }
        

        public CommandVM Save { get; set; }
        public CommandVM Cost { get; set; }

    }

}
