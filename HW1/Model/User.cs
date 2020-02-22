namespace HW1.Model
{
    internal class User
    {
        private string _zodiakYear;
        private string _zodiakSign;
        private int _age;

        public User(int age, string zodiakSign, string zodiakYear)
        {
            _age = age;
            _zodiakSign = zodiakSign;
            _zodiakYear = zodiakYear;
        }


        public string ZodiakYear
        {
            get { return _zodiakYear; }
            set { _zodiakYear = value; }
        }

        public string ZodiakSign
        {
            get { return _zodiakSign; }
            set { _zodiakSign = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

    }
}

