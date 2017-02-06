using System;

using Acr.UserDialogs;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace PC.ViewModels
{
  public class CartaoViewModel : BindableBase
  {
    public CartaoViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
    {
      _navigationService = navigationService;
      _pageDialogService = pageDialogService;
      _userDialogs = userDialogs;

      OnCommandClose = new DelegateCommand(CommandClose);
    }

    private INavigationService _navigationService;
    private IPageDialogService _pageDialogService;
    private IUserDialogs _userDialogs;

    public DelegateCommand OnCommandClose { get; private set; }

    private async void CommandClose()
    {
      await _navigationService.PopupGoBackAsync();
    }
  }
}