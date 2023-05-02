using Firebase.Database;
namespace CapstoneProject;

public partial class App : Application
{
    public static FirebaseClient client = new("https://myfirstdb-f4b55-default-rtdb.asia-southeast1.firebasedatabase.app/");
    //public static string email, key, firstname, middlename, lastname, homeaddress, jobposition, phone;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
