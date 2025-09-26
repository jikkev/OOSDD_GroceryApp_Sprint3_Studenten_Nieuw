using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Grocery.App.ViewModels;

public class RegistrationViewModel : INotifyPropertyChanged
{
    string userName;
    string email;
    string password;
    string confirmPassword;
    string message;
    bool isBusy;

    public event PropertyChangedEventHandler PropertyChanged;

    public string UserName
    {
        get => userName;
        set { if (userName == value) return; userName = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSubmit)); RegisterCommand.ChangeCanExecute(); }
    }

    public string Email
    {
        get => email;
        set { if (email == value) return; email = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSubmit)); RegisterCommand.ChangeCanExecute(); }
    }

    public string Password
    {
        get => password;
        set { if (password == value) return; password = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSubmit)); RegisterCommand.ChangeCanExecute(); }
    }

    public string ConfirmPassword
    {
        get => confirmPassword;
        set { if (confirmPassword == value) return; confirmPassword = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSubmit)); RegisterCommand.ChangeCanExecute(); }
    }

    public string Message
    {
        get => message;
        set { if (message == value) return; message = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasMessage)); }
    }

    public bool HasMessage => !string.IsNullOrWhiteSpace(Message);

    public bool IsBusy
    {
        get => isBusy;
        set { if (isBusy == value) return; isBusy = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSubmit)); RegisterCommand.ChangeCanExecute(); }
    }

    public bool CanSubmit => !IsBusy && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && Password == ConfirmPassword;

    public Command RegisterCommand { get; }

    public RegistrationViewModel()
    {
        RegisterCommand = new Command(async () => await Register(), () => CanSubmit);
    }

    async Task Register()
    {
        IsBusy = true;
        try
        {
            await Task.Delay(500);
            Message = "Account aangemaakt (demo).";
        }
        catch (System.Exception ex)
        {
            Message = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
