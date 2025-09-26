using System;
using Grocery.App.ViewModels;
using Microsoft.Maui.Controls;

namespace Grocery.App.Views;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(RegistrationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

