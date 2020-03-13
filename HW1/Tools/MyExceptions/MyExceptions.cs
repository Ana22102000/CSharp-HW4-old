
using System;

namespace CSharpHomework.Tools.MyExceptions
{
    public class EmailException : Exception
    {
        public EmailException():base()
        {
        }

        public EmailException(string message)
            : base(message)
        {
        }
    }

    public class NotBornException : Exception
    {
        public NotBornException() : base()
        {
        }

        public NotBornException(string message)
            : base(message)
        {
        }
    }

    public class TooOldException : Exception
    {
        public TooOldException() : base()
        {
        }
        public TooOldException(string message)
            : base(message)
        {
        }
    }

    public class NameException : Exception
    {
        public NameException() : base()
        {
        }

        public NameException(string message)
            : base(message)
        {
        }
    }

    public class SurnameException : Exception
    {
        public SurnameException() : base()
        {
        }

        public SurnameException(string message)
            : base(message)
        {
        }
    }
}
