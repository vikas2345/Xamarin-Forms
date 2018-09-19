using FormsMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        public LoginModel loginModel;

		public Login ()
		{
			InitializeComponent ();
            loginModel = new LoginModel();
            MessagingCenter.Subscribe<LoginModel,string>(this, "Login Alert",(sender,username)=>
            {
                DisplayAlert("Title",username, "Oke");
            });
            this.BindingContext = loginModel;

            EntryUsername.Completed += (object sender, EventArgs e) =>
            {
                EntryPassword.Focus();
            };

            EntryPassword.Completed += (object sender, EventArgs e) =>
            {
                loginModel.SubmitCommand.Execute(null);
            };

        }
                
    }
}