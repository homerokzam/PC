using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

using Scandit.BarcodePicker.Unified;

namespace PC.ViewModels
{
  public class MainViewModel : BindableBase
  {
    public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
    {
      _navigationService = navigationService;
      _pageDialogService = pageDialogService;

      OnCommandScan = new DelegateCommand(CommandScan);
      ScanditService.BarcodePicker.DidScan += BarcodePickerOnDidScan;
    }

    private INavigationService _navigationService;
    private IPageDialogService _pageDialogService;

    public DelegateCommand OnCommandScan { get; private set; }

    private async void CommandScan()
    {
      //_pageDialogService.DisplayAlertAsync("Click", "Teste", "Ok", "Cancel");
      await ScanditService.BarcodePicker.StartScanningAsync(false);
    }

    private async void BarcodePickerOnDidScan(ScanSession session)
    {
      var dado = session.NewlyRecognizedCodes.LastOrDefault()?.Data;
      await ScanditService.BarcodePicker.StopScanningAsync();

      _pageDialogService.DisplayAlertAsync("Click", dado, "Ok", "Cancel");
    }
  }
}