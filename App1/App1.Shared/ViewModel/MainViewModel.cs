using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel;
using Windows.UI.Popups;
using App1.Database;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLite;
using System.IO;

namespace App1.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			IntPtr ptr;
			LabelDescription = "ClickMe";
			var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data.db3");
			using (var db = new SQLite.SQLiteConnection(dbpath))
			{			
				// Create the tables if they don't exist 
				db.CreateTable<Person>();
				db.Commit();

				db.Dispose();
				db.Close();
			} 


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
