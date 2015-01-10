using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace App1.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			LabelDescription = "ClickMe";
		}

		private string _labelDescription;

		public string LabelDescription
		{
			get { return _labelDescription; }
			set
			{
				_labelDescription = value;
				RaisePropertyChanged(() => LabelDescription);
			}
		}

		private RelayCommand<string> _firstCommand;

		public RelayCommand<string> FirstCommand
		{
			get
			{
				return _firstCommand ?? (_firstCommand = new RelayCommand<string>(async e =>
										 {
											 var dialog = new MessageDialog(e);
											 await dialog.ShowAsync();
										 }
					));
			}
		}
	}

}
