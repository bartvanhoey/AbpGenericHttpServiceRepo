namespace BookStoreMaui.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        BindingContext = loginViewModel;
        InitializeComponent();
    }
}