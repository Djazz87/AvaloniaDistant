using System.Collections.ObjectModel;
using AvaloniaDistant.Models;
using AvaloniaDistant.Services;
using AvaloniaDistant.ViewModels;

namespace YourProjectName.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<IllnessRecord> IllnessRecords { get; set; }

    public MainWindowViewModel()
    {
        IllnessRecords = new ObservableCollection<IllnessRecord>(
            DataBaseServices.GetIllnessRecords()
            
            
        );
    }
    private Employee _selectedEmployee;

    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set
        {
            if (Equals(value, _selectedEmployee) ) return;
            _selectedEmployee = value;
            OnPropertyChanged();
        }
    }

   
    
    //pagination
    
    
}
