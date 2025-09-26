using Grocery.App.ViewModels;
using Microsoft.Maui.Controls;

namespace Grocery.App.Views;

public partial class GroceryListItemsView : ContentPage
{
    public GroceryListItemsView(GroceryListItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
