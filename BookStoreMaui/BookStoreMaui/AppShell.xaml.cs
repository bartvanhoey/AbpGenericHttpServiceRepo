using BookStoreMaui.Pages.Authors.Edit;
using BookStoreMaui.Pages.Books.Edit;

namespace BookStoreMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(EditBookPage), typeof(EditBookPage));
        Routing.RegisterRoute(nameof(EditAuthorPage), typeof(EditAuthorPage));
    }
}