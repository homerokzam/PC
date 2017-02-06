using System;

using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PC.ViewModels
{
  public class MasterDetailViewModel : BindableBase
  {
    public MasterDetailViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
    {
      _navigationService = navigationService;
      _pageDialogService = pageDialogService;
    }

    private INavigationService _navigationService;
    private IPageDialogService _pageDialogService;
  }
}