using System.ComponentModel;
using System.Diagnostics;

namespace TodoAppDemo.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
#if DEBUG
        this.VerifyPropertyName(propertyName);
#endif
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void VerifyPropertyName(string propertyName)
    {
        if (TypeDescriptor.GetProperties(this)[propertyName] is null)
        {
            throw new ArgumentException($"Property '{propertyName}' not found on '{this.GetType().Name}'.", propertyName);
        }
    }
}
