namespace BookStoreMaui.Pages;

public partial class LogoutPage : ContentPage
{
    public LogoutPage(LogoutViewModel logoutViewModel)
    {
        InitializeComponent();
        BindingContext = logoutViewModel;
    }
}