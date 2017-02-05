using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

using Scandit.BarcodePicker.Unified;
using Xamarin.Forms;

namespace PC.ViewModels
{
  public class MainViewModel : BindableBase, IPageAware
  {
    public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
    {
      _navigationService = navigationService;
      _pageDialogService = pageDialogService;

      OnCommandScan = new DelegateCommand(CommandScan);
      OnCommandSlideOverKit = new DelegateCommand(CommandSlideOverKit);
      ScanditService.BarcodePicker.DidScan += BarcodePickerOnDidScan;
    }

    private INavigationService _navigationService;
    private IPageDialogService _pageDialogService;

    public DelegateCommand OnCommandScan { get; private set; }
    public DelegateCommand OnCommandSlideOverKit { get; private set; }

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
  }
}