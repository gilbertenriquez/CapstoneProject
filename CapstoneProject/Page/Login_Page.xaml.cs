using CapstoneProject.Page;
using CapstoneProject.Model;
using Plugin.Connectivity;
namespace CapstoneProject.Page;

public partial class Login_Page : ContentPage
{
    private Users userlog = new ();
	public Login_Page()
	{
		InitializeComponent();
	}

    private async void lognBTN_Clicked(object sender, EventArgs e)
    {
        var a = await userlog.UserLogin(txtemail.Text, txtpass.Text);
        if (string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtpass.Text))
        {
            await DisplayAlert("Alert!", "Please Fill up your Email or Password!", "Got it!");
            txtemail.Text = "";
            txtpass.Text = "";
            return;
        }
        progressLoading.IsVisible = true;
        if (a)
        {
            await DisplayAlert("Alert!", "Access Granted!", "OK!");
            txtemail.Text = "";
            txtpass.Text = "";
            Application.Current!.MainPage = new AppShell();
            progressLoading.IsVisible = false;
            return;

        }
        IC_check();
        await DisplayAlert("Alert!", "Access Denied!", "OK!");
        progressLoading.IsVisible = false;
        txtemail.Text = "";
        txtpass.Text = "";
    }

    private async void IC_check()
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            return;
        }
        await DisplayAlert("Alert", "No Internet Connection", "OK!");
        return;
    }

       private async void SignUpBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUp_Page());
    }
}