using System;
using System.Windows;
using CSharpHomework.Model;
using CSharpHomework.Tools.DataStorage;

namespace CSharpHomework.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;


        internal static Person CurrentUser { get; set; }

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
        
        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
