using HW1.Tools;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using HW1.Model;
using HW1.Tools.Managers;


namespace HW1.ViewModel
{
    internal class DateViewModel : BaseViewModel
    {


        #region Fields
         private string _age;

        private DateTime _selectedDate=DateTime.Now;
        private string _zodiakSign;
        private string _zodiakYear;


        #region Commands
        private RelayCommand<object> _calculateCommand;
        #endregion
        #endregion

        #region Properties
      

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string ZodiakSign
        {
            get { return _zodiakSign; }
            set
            {
                _zodiakSign = value;
                OnPropertyChanged(nameof(ZodiakSign));
            }
        }

        public string ZodiakYear
        {
            get { return _zodiakYear; }
            set
            {
                _zodiakYear = value;
                OnPropertyChanged(nameof(ZodiakYear));
            }
        }

        public DateTime SelectedDate
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
            return _selectedDate != null;
        }
        private async void CalculateImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(2000));

            await Task.Run(()=>CountInformation());

            LoaderManager.Instance.HideLoader();
        }


        private void CountInformation()
        {
            // MessageBox.Show("You get it");
            DateTime now = DateTime.Now;




            Thread myThread = new Thread(new ThreadStart( Count));
            myThread.Start();

            

            


        }

        private void Count()
        {
            DateTime now = DateTime.Now;

            int age = now.Year - SelectedDate.Year;

            // for leap years we need this
            if (SelectedDate > now.AddYears(-age)) age--;
            // don't use:
            // if (birthDate.AddYears(age) > now) age--;

            Age = age.ToString();


            if (Int32.Parse(Age) < 0 || Int32.Parse(Age) > 135)
            {
                MessageBox.Show("Wrong date (More than 135 or less than 0 years old)");
                Age = "";
                ZodiakSign = "";
                ZodiakYear = "";

            }
            else
            {

                Thread myThread = new Thread(new ThreadStart(CountZodiakSign));
                myThread.Start();

                myThread = new Thread(new ThreadStart(CountZodiakYear));
                myThread.Start();

                User user = new User(Int32.Parse(Age), ZodiakSign, ZodiakYear);

                if (SelectedDate.Day == now.Day && SelectedDate.Month == now.Month)
                    MessageBox.Show("Happy B-Day, dear!");

            }

        }

        private void CountZodiakSign()
        {
            switch (SelectedDate.Month)
            {
                case 1:
                    if (SelectedDate.Day <= 20)
                    { ZodiakSign = "Your zodiac sign is Capricorn"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Aquarius"; }
                    break;
                case 2:
                    if (SelectedDate.Day <= 19)
                    { ZodiakSign = "Your zodiac sign is Aquarius"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Pisces"; }
                    break;
                case 3:
                    if (SelectedDate.Day <= 20)
                    { ZodiakSign = "Your zodiac sign is Pisces"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Aries"; }
                    break;
                case 4:
                    if (SelectedDate.Day <= 20)
                    { ZodiakSign = "Your zodiac sign is Aries"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Taurus"; }
                    break;
                case 5:
                    if (SelectedDate.Day <= 21)
                    { ZodiakSign = "Your zodiac sign is Taurus"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Gemini"; }
                    break;
                case 6:
                    if (SelectedDate.Day <= 22)
                    { ZodiakSign = "Your zodiac sign is Gemini"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Cancer"; }
                    break;
                case 7:
                    if (SelectedDate.Day <= 22)
                    { ZodiakSign = "Your zodiac sign is Cancer"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Leo"; }
                    break;
                case 8:
                    if (SelectedDate.Day <= 23)
                    { ZodiakSign = "Your zodiac sign is Leo"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Virgo"; }
                    break;
                case 9:
                    if (SelectedDate.Day <= 23)
                    { ZodiakSign = "Your zodiac sign is Virgo"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Libra"; }
                    break;
                case 10:
                    if (SelectedDate.Day <= 23)
                    { ZodiakSign = "Your zodiac sign is Libra"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Scorpio"; }
                    break;
                case 11:
                    if (SelectedDate.Day <= 22)
                    { ZodiakSign = "Your zodiac sign is Scorpio"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Sagittarius"; }
                    break;
                case 12:
                    if (SelectedDate.Day <= 21)
                    { ZodiakSign = "Your zodiac sign is Sagittarius"; }
                    else
                    { ZodiakSign = "Your zodiac sign is Capricorn"; }
                    break;

            }
        }

        private void CountZodiakYear()
        {

            switch (SelectedDate.Year % 12)
            {
                case 0:
                    ZodiakYear = "Your zodiak year is Monkey";
                    break;
                case 1:
                    ZodiakYear = "Your zodiak year is Rooster";
                    break;
                case 2:
                    ZodiakYear = "Your zodiak year is Dog";
                    break;
                case 3:
                    ZodiakYear = "Your zodiak year is Pig";
                    break;
                case 4:
                    ZodiakYear = "Your zodiak year is Rat";
                    break;
                case 5:
                    ZodiakYear = "Your zodiak year is Ox";
                    break;
                case 6:
                    ZodiakYear = "Your zodiak year is Tiger";
                    break;
                case 7:
                    ZodiakYear = "Your zodiak year is Rabbit";
                    break;
                case 8:
                    ZodiakYear = "Your zodiak year is Dragon";
                    break;
                case 9:
                    ZodiakYear = "Your zodiak year is Snake";
                    break;
                case 10:
                    ZodiakYear = "Your zodiak year is Horse";
                    break;
                case 11:
                    ZodiakYear = "Your zodiak year is Goat";
                    break;


            }

        }

    }
}
