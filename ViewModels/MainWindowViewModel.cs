using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EmployeePortal.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeService _employeeService;
        private Employee? _selectedEmployee;
        public RelayCommand? AddEmployeeCommand { get; set; }

        public RelayCommand? SaveEmployeeCommand { get; set; }

        public RelayCommand CancelEmployeeCommand { get; }

        public RelayCommand BrowsePhotoCommand { get; }

        public RelayCommand DeleteEmployeeCommand { get; }

        private string _errorMessage = string.Empty;

        public MainWindowViewModel()
        {
            _employeeService = new EmployeeService();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            NewEmployee = new Employee();
            SaveEmployeeCommand = new RelayCommand(SaveEmployee);
            CancelEmployeeCommand = new RelayCommand(CancelEmployee);
            BrowsePhotoCommand = new RelayCommand(BrowsePhoto);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee,() => SelectedEmployee != null);
        }

        public ObservableCollection<Employee> Employees
        {
            get { return _employeeService.Employees; }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                
                    _selectedEmployee = value;
                NotifyPropertyChanged(nameof(SelectedEmployee));

                NotifyPropertyChanged(nameof(HasSelectedEmployee));

                DeleteEmployeeCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool HasSelectedEmployee
        {
            get
            {
                return SelectedEmployee != null;
            }
        }

        private bool _isAddEmployeeFormVisible;

        public bool IsAddEmployeeFormVisible
        {
            get
            {
                return _isAddEmployeeFormVisible;
            }
            set
            {
                _isAddEmployeeFormVisible = value;

                NotifyPropertyChanged(nameof(IsAddEmployeeFormVisible));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;

                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }

        private Employee _newEmployee;

        public Employee NewEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                _newEmployee = value;

                NotifyPropertyChanged(nameof(NewEmployee));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Array GenderOptions
        {
            get
            {
                return Enum.GetValues(typeof(Gender));
            }
        }
        private void AddEmployee()
        {
            IsAddEmployeeFormVisible = true;
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee == null)
                return;

            _employeeService.DeleteEmployee(SelectedEmployee);

            SelectedEmployee = null;
        }

        private void SaveEmployee()
        {
            if (string.IsNullOrWhiteSpace(NewEmployee.Name))
            {
                ErrorMessage = "Name is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewEmployee.Address))
            {
                ErrorMessage = "Address is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewEmployee.PhoneNumber))
            {
                ErrorMessage = "Phone number is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewEmployee.Email))
            {
                ErrorMessage = "Email is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewEmployee.Position))
            {
                ErrorMessage = "Position is required.";
                return;
            }

            if(string.IsNullOrWhiteSpace(NewEmployee.PhotoPath))
            {
                ErrorMessage = "Photo is required.";
                return;
            }

            _employeeService.AddEmployee(NewEmployee);

            NewEmployee = new Employee();

            ErrorMessage = string.Empty;

            IsAddEmployeeFormVisible = false;
        }

        private void CancelEmployee()
        {
            NewEmployee = new Employee();
            IsAddEmployeeFormVisible = false;
        }

        private void BrowsePhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                NewEmployee.PhotoPath = dialog.FileName;
            }
        }

    }
}
