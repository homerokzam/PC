using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Prism.Common;
using SlideOverKit;

namespace PC.Views
{
  public partial class Main : MenuContainerPage, IMenuContainerPage
  {
    public Main()
    {
      this.BindingContextChanged += (sender, args) =>
      {
        var pageAware = this.BindingContext as IPageAware;
        if (pageAware != null)
        {
          pageAware.Page = this;
        }
      };
      
      InitializeComponent();

      this.SlideMenu = new SlideDownMenuView();
    }

    public Action HideMenuAction { get; set; }
    public Action ShowMenuAction { get; set; }
    public SlideMenuView SlideMenu { get; set; }
  }
}