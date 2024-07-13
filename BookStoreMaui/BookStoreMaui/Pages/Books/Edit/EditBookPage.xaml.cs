namespace BookStoreMaui.Pages.Books.Edit;


public partial class EditBookPage : ContentPage
{
    private readonly EditBookViewModel _vm;

    public EditBookPage(EditBookViewModel editBookViewModel)
    {
        BindingContext = _vm = editBookViewModel;
        InitializeComponent();
    }

    protected override async void OnAppearing() 
        => await _vm.OnAppearing();
}