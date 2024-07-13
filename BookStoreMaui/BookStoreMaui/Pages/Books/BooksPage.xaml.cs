using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreMaui.Pages.Books;

public partial class BooksPage : ContentPage
{
    private readonly BooksViewModel _vm;

    public BooksPage(BooksViewModel booksViewModel)
    {
        BindingContext = _vm = booksViewModel;
        InitializeComponent();
    }
    
    protected override async void OnAppearing() => await _vm.OnAppearing();
}