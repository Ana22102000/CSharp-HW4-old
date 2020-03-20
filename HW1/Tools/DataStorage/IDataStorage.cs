using System.Collections.Generic;
using CSharpHomework.Model;

namespace CSharpHomework.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool UserExists(string login);

        Person GetUserByLogin(string login);

        void AddUser(Person user);
        void RemoveUser(Person user);


        List<Person> UsersList { get; }
    }
}
