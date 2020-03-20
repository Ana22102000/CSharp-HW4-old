using System;
using MainView = CSharpHomework.View.MainView;
using AddUserView = CSharpHomework.View.Date;

namespace CSharpHomework.Tools.Navigation
{
    internal class AuthenticationNavigationModel : BaseNavigationModel
    {


        //private readonly IContentOwner _contentOwner;//

        public AuthenticationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            //this._contentOwner = _contentOwner;//
        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AddPerson:
                    AddView(ViewType.AddPerson, new AddUserView());
                    break;
                case ViewType.Main:
                    AddView(ViewType.Main, new MainView());
                    break;
               
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }


    }
}
