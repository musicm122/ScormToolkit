using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HackerFerretCommon.Helpers
{
    public static class DialogHelper
    {
        public static List<string> GetZipFiles(string title = "")
        {
            var retval = new List<string>();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = title;
            openFileDialog.Filter = "Zip files (*.zip)|*.zip";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                retval = openFileDialog.FileNames.ToList<string>();
            }
            return retval;
        }

        public static void ShowInfoDialog(string title = "Information", string body = "")
        {
            // Configure the message box to be displayed
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(body, title, button, icon);
        }

        public static bool ShowConfirmationDialog(string title = "Please Confirm", string body = "")
        {
            // Configure the message box to be displayed
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            var result = MessageBox.Show(body, title, button, icon);
            return result == MessageBoxResult.OK;
        }

        public static void ShowErrorDialog(string title = "Error", string body = "")
        {
            // Configure the message box to be displayed
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(body, title, button, icon);
        }



    }

    public static class OsHelper
    {
        public static string PasteFromClipboard()
        {
            return System.Windows.Forms.Clipboard.GetText();
            //return System.Windows.Clipboard.SetText(SelectedCourse);
        }

        public static void CopyToClipboard(string text)
        {
            System.Windows.Forms.Clipboard.SetText(text);
            //return System.Windows.Clipboard.SetText(SelectedCourse);
        }
    }
}
