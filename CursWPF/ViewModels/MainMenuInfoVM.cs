using CursLib.Models;
using CursWPF.Tools;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using Information = CursLib.Models.Information;

namespace CursWPF.ViewModels
{
    public class MainMenuInfoVM : BaseTools 
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

        public string Title { get; set; }

        public Information SelectedItem { get; set; }

        private List<Information> informations;

        public List<Information> Information
        {
            get => informations;
            set
            {
                informations = value;

                Signal();
            }
        }
        public CommandVM Save { get; set; }
        public CommandVM DeleteInformation { get; set; }

        public MainMenuInfoVM()
        {

            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Information", "ListInformations", null);
                Information = HttpApi.Deserialize<List<Information>>(json);



            });


            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;

            Save = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Information", "save", new Information
                {
                    Title = Title,
                    
                });
                Information result = HttpApi.Deserialize<Information>(json);

                MessageBox.Show("Сохранилось");
                
            });

            DeleteInformation = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Information", "delete", SelectedItem.InformationId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Information", "ListInformations", null);
                    Information = HttpApi.Deserialize<List<Information>>(json);

                });
            });

        }
    }

}
