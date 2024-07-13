using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreMaui.Pages.Authors.Edit;

public partial class EditAuthorPage : ContentPage
{
    private readonly EditAuthorViewModel _vm;

    public EditAuthorPage(EditAuthorViewModel editAuthorViewModel)
    {
        BindingContext = _vm= editAuthorViewModel;
        InitializeComponent();
    }
    
    protected override async void OnAppearing() 
        => await _vm.OnAppearing();
}