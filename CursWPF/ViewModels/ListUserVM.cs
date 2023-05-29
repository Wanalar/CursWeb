using CursLib.Models;
using CursWPF.Tools;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursWPF.ViewModels
{
    public class ListUserVM :  BaseTools
    {
        public User SelectedItem { get; set; }
        private List<User> user;
        private List<Role> role;
        public User userere { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public int PhonNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        private Role roles;

        public Role SelectedRole
        {
            get => roles;
            set
            {
                roles = value;
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

        public List<Role> Role
        {
            get => role;
            set
            {
                role = value;

                Signal();
            }
        }

        public CommandVM DeleteUser { get; set; }
        public CommandVM Edit { get; set; }
        public CommandVM Save { get; set; }
        public Role Title { get;  set; }

        public ListUserVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Users", "ListUsers", null);
                User = HttpApi.Deserialize<List<User>>(json);

                var json2 = await HttpApi.Post("Roles", "list", null);
                Role = HttpApi.Deserialize<List<Role>>(json2);

            });

            //Edit = new CommandVM(async () =>
            //{
                //userere = SelectedItem;
              //  new EditUsers(userere).Show();
            //});


            Save = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Users", "SaveUser", new User
                {
                    FirstName = FirstName,
                    SecondName = SecondName,
                    Patronymic = Patronymic,
                    PhonNumber = PhonNumber,
                    Email = Email,
                    Login = Login,
                    Password = Password,
                    Role = SelectedRole.RoleId
                });
                User result = HttpApi.Deserialize<User>(json);

                MessageBox.Show("Сохранилось!");

            });

           
            DeleteUser = new CommandVM(async () =>
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show("Ошибка");
                }
                else
                {
                    var json = await HttpApi.Post("Users", "delete", SelectedItem.UserId);

                    Task.Run(async () =>
                    {
                        var json = await HttpApi.Post("Users", "ListUsers", null);
                        User = HttpApi.Deserialize<List<User>>(json);

                        
                    });
                }
            });

        }

    }

}
