using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CustomT.UI.UserControls
{
  /// <summary>
  /// Interaction logic for ToggleButton.xaml
  /// Requires inheritance from the old INotifyPropertyChanged rather than the newer
  /// CommunityToolkit ObservableObject because of the use of DependencyProperties.
  /// </summary>
  public partial class ToggleButton : UserControl, INotifyPropertyChanged
  {
    public ToggleButton()
    {
      InitializeComponent();
    }

    // ******************************
    // Create two DependencyProperties on this UserControl to allow custom data binding.
    // OptionList allows a List<string> to be data bound to the user control and is then
    // bound internally to the TextBlocks on the left and right side of the UserControl.
    // SelectedOption is used for outgoing data binding.  When the toggle is changed,
    // the SelectedOption property changes between the value of the left
    // TextBlock.Text and the right.
    // ******************************


    /// <summary>
    /// Register and attach to the UserControl the OptionList DependencyProperty
    /// </summary>
    public static readonly DependencyProperty OptionListProperty =
      DependencyProperty.RegisterAttached(
        "OptionList",
        typeof(List<string>),
        typeof(ToggleButton),
        new PropertyMetadata(new List<string>()));

    /// <summary>
    /// Register and attach to the UserControl the SelectedOption DependencyProperty
    /// </summary>
    public static readonly DependencyProperty SelectedOptionProperty =
      DependencyProperty.RegisterAttached(
        "SelectedOption",
        typeof(string),
        typeof(ToggleButton),
        new PropertyMetadata(String.Empty));

    /// <summary>
    /// Declare the OptionList DependencyProperty
    /// </summary>
    public List<string> OptionList
    {
      get => (List<string>)GetValue(OptionListProperty);
      set => SetValue(OptionListProperty, value);
    }

    /// <summary>
    /// Declare the SelectedOption DependencyProperty
    /// </summary>
    public string SelectedOption
    {
      get => (string)GetValue(SelectedOptionProperty);
      set => SetValue(SelectedOptionProperty, value);
    }

    /// <summary>
    /// IsChecked Property for standard data binding to the toggle.
    /// </summary>
    private bool isChecked;
    public bool IsChecked
    {
      get => isChecked;
      set
      {
        if (value != isChecked)
        {
          isChecked = value;
          // When the value of IsChecked changes (toggle has been switched), 
          // set the SelectedOption property.
          SetSelectedOption();
          NotifyPropertyChanged();
        }
      }
    }

    ///// <summary>
    ///// Method that executes when OptionList property changes.  It is a static method
    ///// whose main purpose is to call the instance method where custom code can be inserted.
    ///// </summary>
    ///// <param name="d">DependencyObject parameter, the OptionList in this case.</param>
    ///// <param name="e">event arguments</param>
    //private static void OnOptionListChanged(DependencyObject d,
    //DependencyPropertyChangedEventArgs e)
    //{
    //  ToggleButton objectInstance = (ToggleButton)d;
    //  objectInstance.OnOptionListChanged(e);
    //  objectInstance.NotifyPropertyChanged(e.Property.Name);
    //}

    ///// <summary>
    ///// Method that executes when SelectedOption property changes.  It is a static method
    ///// whose main purpose is to call the instance method where custom code can be inserted.
    ///// </summary>
    ///// <param name="d">DependencyObject parameter, the SelectedOption in this case.</param>
    ///// <param name="e">event arguments</param>
    //private static void OnSelectedOptionChanged(DependencyObject d,
    //DependencyPropertyChangedEventArgs e)
    //{
    //  ToggleButton objectInstance = (ToggleButton)d;
    //  objectInstance.OnSelectedOptionChanged(e);
    //  objectInstance.NotifyPropertyChanged(e.Property.Name);
    //}

    ///// <summary>
    ///// Stub method that can have custom code inserted to execute when property changes.
    ///// </summary>
    ///// <param name="e"></param>
    //private void OnOptionListChanged(DependencyPropertyChangedEventArgs e)
    //{
    //  if (OptionList == null) return;
    //  //Do stuff here for this object instance.
    //}

    ///// <summary>
    ///// Stub method that can have custom code inserted to execute when property changes.
    ///// </summary>
    ///// <param name="e"></param>
    //private void OnSelectedOptionChanged(DependencyPropertyChangedEventArgs e)
    //{
    //  if (SelectedOption == null) return;
    //  //Do stuff here for this object instance.
    //}

    /// <summary>
    /// Method to set the SelectedOption property based on the first two items in
    /// OptionList.
    /// </summary>
    private void SetSelectedOption()
    {
      if ((OptionList != null) && (OptionList.Count >= 2))
      {
        if (IsChecked)
          SelectedOption = OptionList[1];
        else
          SelectedOption = OptionList[0];
      }
    }


    // Below here is the implementation of the INotifyPropertyChanged interface.  This
    // code is required for any class inheriting INotifyPropertyChanged.

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }




  }
}
