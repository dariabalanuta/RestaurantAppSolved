using RestaurantApp.Models;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Table table { get; set; }
        private string _username;
        public string Username
        {
            set
            {
                this._username = value;
                OnPropertyChanged();
            }
            get { return this._username; }
        }

        public string _password;
        public string Password
        {
            set { this._password = value; OnPropertyChanged(); }
            get { return this._password; }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set { this._IsBusy = value; OnPropertyChanged(); }
            get { return this._IsBusy;}
        }

        private bool _Result;
        public bool Result 
        {
            set { this._Result = value; OnPropertyChanged(); }
            get { return this._Result; }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());

        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserServices();
                Result = await userService.UserRegister(Username, Password);
                if(Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registred", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "User already exists with this credentials", "OK");
                }
            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserServices();
                Result = await userService.LoginUser(Username, Password);
                if( Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new TablesView(table));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
