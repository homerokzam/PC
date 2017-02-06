using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Acr.UserDialogs;
using Microsoft.Practices.Unity;
using Prism.Unity;

using PC.Views;

namespace PC
{
  public partial class App : PrismApplication
  {
    protected override void OnInitialized()
    {
      InitializeComponent();
      NavigationService.NavigateAsync("/MasterDetail/NavigationPage/Main");
    }

    protected override void RegisterTypes()
    {
      RegisterNavigation();
      RegisterServices();
    }

    void RegisterNavigation()
    {
      Container.RegisterTypeForNavigation<NavigationPage>();
      Container.RegisterTypeForNavigation<MasterDetail>();
      Container.RegisterTypeForNavigation<Main>();
      Container.RegisterTypeForNavigation<CartaoView>();
    }

    void RegisterServices()
    {
      Container.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
    }
  }
}