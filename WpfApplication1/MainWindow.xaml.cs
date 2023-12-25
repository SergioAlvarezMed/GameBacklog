﻿using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private GridClickController _controller;
        
        public MainWindow()
        {
            InitializeComponent();
            
            _controller = new GridClickPrinterController();
        }
        

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _controller.handle_click(new System.Collections.Generic.Dictionary<string, string>
            {
                { "x", e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture) },
                { "y", e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture) }
            });
            
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnOpened(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClosed(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}