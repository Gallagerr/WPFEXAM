using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamWPF
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.textbox.PreviewTextInput += new TextCompositionEventHandler(textboxPreviewTextInput);
    }

    private void textboxPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string json = ($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit={textbox.Text}");
      var data = JsonConvert.DeserializeObject<FeatureCollection>(json);
      List<Property> features = new List<Property>();
      foreach (var feature in data.Features)
      {
        features.Add(feature.Properties);
      }
      datagrid.ItemsSource = features;
    }
  }
}
