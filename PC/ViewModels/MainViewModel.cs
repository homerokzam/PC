using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Acr.UserDialogs;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

using Scandit.BarcodePicker.Unified;
using Xamarin.Forms;

using PC.Views;

namespace PC.ViewModels
{
  public class MainViewModel : BindableBase, IPageAware
  {
    public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
    {
      _navigationService = navigationService;
      _pageDialogService = pageDialogService;
      _userDialogs = userDialogs;

      OnCommandScan = new DelegateCommand(CommandScan);
      OnCommandSlideOverKit = new DelegateCommand(CommandSlideOverKit);
      OnCommandRgPluginsPopup = new DelegateCommand(CommandRgPluginsPopup);
      ScanditService.BarcodePicker.DidScan += BarcodePickerOnDidScan;
    }

    private INavigationService _navigationService;
    private IPageDialogService _pageDialogService;
    private IUserDialogs _userDialogs;

    public DelegateCommand OnCommandScan { get; private set; }
    public DelegateCommand OnCommandSlideOverKit { get; private set; }
    public DelegateCommand OnCommandRgPluginsPopup { get; private set; }

    public Page Page { get; set; }

    private async void CommandScan()
    {
      await ScanditService.BarcodePicker.StartScanningAsync(false);
    }

    private async void BarcodePickerOnDidScan(ScanSession session)
    {
      var dado = session.NewlyRecognizedCodes.LastOrDefault()?.Data;
      await ScanditService.BarcodePicker.StopScanningAsync();

      _pageDialogService.DisplayAlertAsync("Click", dado, "Ok", "Cancel");
    }

    private async void CommandSlideOverKit()
    {
      PC.Views.Main page = (PC.Views.Main)Page;
      if (page.SlideMenu.IsShown)
      {
        page.HideMenuAction?.Invoke();
      }
      else {
        page.ShowMenuAction?.Invoke();
      }
    }

    private async void CommandRgPluginsPopup()
    {
      //CartaoView view = new CartaoView();
      //await this.Page.Navigation.PushPopupAsync(view);

      await _navigationService.PushPopupPageAsync("CartaoView");
    }
  }
}