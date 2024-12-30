using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePopup
{
    public class ViewModel:INotifyPropertyChanged
    {
        private bool _isDarkModeEnabled;
        private bool _areNotificationsEnabled;
        public ObservableCollection<Notes> NotesList { get; set; }
        public ViewModel() 
        {
            NotesList = new ObservableCollection<Notes>();
            GenerateInfo();
        }

        public bool IsDarkModeEnabled
        {
            get { return _isDarkModeEnabled; }
            set { _isDarkModeEnabled = value; OnPropertyChanged("IsDarkModeEnabled"); }
        }

        public bool IsNotificationsEnabled
        {
            get { return _areNotificationsEnabled; }
            set { _areNotificationsEnabled = value; OnPropertyChanged("IsNotificationsEnabled"); }
        }

        public void GenerateInfo()
        {
            NotesList.Add(new Notes { Title = "Shopping List", Description = "Milk, Bread, Eggs" });
            NotesList.Add(new Notes { Title = "Meeting Notes", Description = "Discuss project milestones" });
            NotesList.Add(new Notes { Title = "Workout Plan", Description = "3x a week - Cardio and Strength" });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
