using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreMaui.Pages.Authors;

public partial class AuthorsPage : ContentPage
{
    private readonly AuthorsViewModel _vm;

    public AuthorsPage(AuthorsViewModel authorsViewModel)
    {
        InitializeComponent();
        BindingContext = _vm= authorsViewModel;
    }

    protected override async void OnAppearing() => await _vm.OnAppearing();
}