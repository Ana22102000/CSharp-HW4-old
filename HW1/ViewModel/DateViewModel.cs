using CSharpHomework.Tools;
using System;
using System.Threading.Tasks;
using System.Windows;
using CSharpHomework.Model;
using CSharpHomework.Tools.Managers;
using CSharpHomework.Tools.Navigation;


namespace CSharpHomework.ViewModel
{
    internal class DateViewModel : BaseViewModel
    {

        #region Fields
        private string _name;
        private string _surname;
        private string _email;


        private Nullable<DateTime> _selectedDate=DateTime.Now;

        #region Commands
        private RelayCommand<object> _calculateCommand;
        private RelayCommand<object> _cancelCommand;

        
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

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o =>
                {

                    if(_defPerson!=null)
                        StationManager.DataStorage.AddUser(_defPerson);

                    _defPerson = null;

                    NavigationManager.Instance.Navigate(ViewType.Main);

                }));
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
        }
        private async void CalculateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();

            await Task.Run(() => CreatePerson());

            _defPerson = null;

            LoaderManager.Instance.HideLoader();


            NavigationManager.Instance.Navigate(ViewType.Main);

        }

        private void CreatePerson()
        {

            try
            {
                Person person = new Person(Name, Surname, Email, (DateTime) SelectedDate);

                DateTime now = DateTime.Now;

                int age = now.Year - person.Birthday.Year;

                // for leap years we need this
                if (person.Birthday > now.AddYears(-age)) age--;
                // don't use:
                // if (birthDate.AddYears(age) > now) age--;

                if (person.IsBirthday)
                    MessageBox.Show("Happy B-Day, dear!");

                StationManager.DataStorage.AddUser(person);

            }
            catch (Exception e)
            {
                //PersonInfo = "";
                MessageBox.Show(e.Message);
            }
            finally
            {
                Name = "";
                Surname = "";
                Email = "";
                SelectedDate=DateTime.Now;
            }

        }


        public DateViewModel()

        {
            if (_defPerson != null)
            {
                Name = _defPerson.Name;
                Surname = _defPerson.Surname;
                Email = _defPerson.Email;
                SelectedDate = _defPerson.Birthday;

            }
        }

        static private Person _defPerson=null;
        public static void SetFields(Person person)
        {
            _defPerson=new Person(person.Name,person.Surname,person.Email,person.Birthday);
            
        }


    }
}
