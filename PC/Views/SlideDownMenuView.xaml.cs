using System;
using System.Collections.Generic;

using Xamarin.Forms;

using SlideOverKit;

namespace PC.Views
{
  public partial class SlideDownMenuView : SlideMenuView
  {
    public SlideDownMenuView()
    {
      InitializeComponent();

      this.HeightRequest = 450;

      this.IsFullScreen = true;
      this.MenuOrientations = MenuOrientation.TopToBottom;

      this.BackgroundColor = Color.FromHex("#D8DDE7");
      this.BackgroundViewColor = Color.Transparent;

      if (Device.OS == TargetPlatform.Android)
        this.HeightRequest += 50;
    }
  }
}