namespace CSharpHomework.Tools.Navigation
{
    internal enum ViewType
    {
        AddPerson=0,
        Main=1,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
