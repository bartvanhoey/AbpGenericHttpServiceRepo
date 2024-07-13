using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreMaui.Pages.Authors.Add;

public partial class AddAuthorPage : ContentPage
{
    public AddAuthorPage(AddAuthorViewModel addAuthorViewModel)
    {
        BindingContext = addAuthorViewModel;
        InitializeComponent();
    }
    
}