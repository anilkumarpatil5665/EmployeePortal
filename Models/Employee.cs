
using System.ComponentModel;

namespace EmployeePortal.Models
{
    public class Employee : INotifyPropertyChanged
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public bool IsMarried { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public string ReportingTo { get; set; }

        public string ProjectName { get; set; }

        private string _photoPath;

        public string PhotoPath
        {
            get
            {
                return _photoPath;
            }
            set
            {
                _photoPath = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(PhotoPath)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}