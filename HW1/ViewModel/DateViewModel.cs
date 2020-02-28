using CSharpHomework.Tools;
using System;
using System.Threading.Tasks;
using System.Windows;
using CSharpHomework.Model;
using CSharpHomework.Tools.Managers;


namespace CSharpHomework.ViewModel
{
    internal class DateViewModel : BaseViewModel
    {

        #region Fields
        private string _name;
        private string _surname;
        private string _email;

        private string _personInfo;

        private Nullable<DateTime> _selectedDate=DateTime.Now;

        #region Commands
        private RelayCommand<object> _calculateCommand;
        #endregion
        #endregion

        #region Properties


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PersonInfo
        {
            get { return _personInfo; }
            set
            {
                _personInfo = value;
                OnPropertyChanged(nameof(PersonInfo));
            }
        }

        public Nullable<DateTime> SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(
                           CalculateImplementation, o => CanExecuteCommand()));
            }
        }


        #endregion
        #endregion


        private bool CanExecuteCommand()
        {
            return !(string.IsNullOrWhiteSpace(Name)
                     || string.IsNullOrWhiteSpace(Surname)
                     || string.IsNullOrWhiteSpace(Email)
                     || SelectedDate==null
                     );
            //return _selectedDate != null;
        }
        private async void CalculateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            // await Task.Run(() => Thread.Sleep(2000));

            await Task.Run(() => CreatePerson());

            LoaderManager.Instance.HideLoader();
        }

        private void CreatePerson()
        {
           
                Person person = new Person(Name, Surname, Email, (DateTime)SelectedDate);

                DateTime now = DateTime.Now;

                int age = now.Year - person.Birthday.Year;

                // for leap years we need this
                if (person.Birthday > now.AddYears(-age)) age--;
                // don't use:
                // if (birthDate.AddYears(age) > now) age--;

                if (age < 0 || age > 135)
                {
                    PersonInfo = "";
                    MessageBox.Show("Wrong age (More than 135 or less than 0 years old)");
                }
            else {
                // throw new System.ArgumentException("Wrong age (More than 135 or less than 0 years old)");

                PersonInfo = "Name: " + person.Name + Environment.NewLine +
                             "Surname:" + person.Surname + Environment.NewLine +
                             "Email: " + person.Email + Environment.NewLine +
                             "Birthday: " + person.Birthday.Date.ToShortDateString() + Environment.NewLine +
                             "IsAdult: " + person.IsAdult + Environment.NewLine +
                             "SunSign: " + person.SunSign + Environment.NewLine +
                             "ChineseSign: " + person.ChineseSign + Environment.NewLine +
                             "IsBirthday: " + person.IsBirthday;

                if (person.IsBirthday)
                    MessageBox.Show("Happy B-Day, dear!");
            
                }
           
        }

    }
}
