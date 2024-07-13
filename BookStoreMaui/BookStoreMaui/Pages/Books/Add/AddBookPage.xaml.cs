using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreMaui.Pages.Books.Add;

public partial class AddBookPage : ContentPage
{
    public AddBookPage(AddBookViewModel addBookViewModel)
    
    {
        BindingContext = addBookViewModel;
        InitializeComponent();
        // Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        // {
        //     TextOverride = "Back",
        // });
    }
}