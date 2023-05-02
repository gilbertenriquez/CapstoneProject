using CapstoneProject.Model;
namespace CapstoneProject.Page;

public partial class SignUp_Page : ContentPage
{
    private Users user = new ();
	public SignUp_Page()
	{
		InitializeComponent();
	}

    private async void btn_register_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtfname.Text) || string.IsNullOrEmpty(txtlname.Text) || string.IsNullOrEmpty(txtmail.Text) || string.IsNullOrEmpty(txtpw.Text))
        {
            await DisplayAlert("Alert!", "Fill up the Empty Fields", "Got it!");
            return;
        }

        if (txtcfpw.Text == txtpw.Text)
        {

        }
        else
        {
            await DisplayAlert("Alert!", "Password is Not Match", "Ok!");
            return;
        }

           progressLoading.IsVisible = true;
        var result = await user.AddUsers(txtfname.Text, txtlname.Text, txtmail.Text, txtpw.Text);
        if (result == true)
        {
            await DisplayAlert("Alert!", "Account Successfully Created", "Ok!");
            await Navigation.PopAsync();
            progressLoading.IsVisible = false;
            return;

        }
        else
        {

            await DisplayAlert("Alert", "Account Not Registered or your Email is already Exist or No Internet Connection", " OK!");
            progressLoading.IsVisible = false;
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}