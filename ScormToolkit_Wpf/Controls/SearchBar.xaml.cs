//http://stackoverflow.com/questions/29126224/how-do-i-bind-wpf-commands-between-a-usercontrol-and-a-parent-window
using RusticiSoftware.HostedEngine.Client;
using ScormLogic.ViewModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ScormToolkit_Wpf.Controls
{
    /// <summary>
    /// Interaction logic for SearchBarUserControl.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {

        public SearchBar()
        {
            InitializeComponent();
        }

        public event EventHandler TextChangedEvent;
        public event EventHandler FilterCollectionEvent;

        //public event FilterCollection(object sender, System.EventArgs e);

        #region Value DP
        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public String CountText
        {
            get { return (string)GetValue(CountTextProperty); }
            set { SetValue(CountTextProperty, value); }
        }

        public String SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set
            {
                SetValue(SearchTextProperty, value);
                TextChangedEvent(this, EventArgs.Empty);
            }
        }

        public IList CollectionSource
        {
            get { return (IList)GetValue(CollectionSourceProperty); }
            set
            {
                SetValue(CollectionSourceProperty, value);
                FilterCollectionEvent(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty CountTextProperty =
            DependencyProperty.Register("CountText", typeof(string), typeof(SearchBar));


        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(SearchBar));

        public static DependencyProperty CollectionSourceProperty =
            DependencyProperty.Register("CollectionSource", typeof(IEnumerable), typeof(SearchBar));


        #endregion


        public virtual void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextChangedEvent?.Invoke(sender, e);
        }
    }
}
