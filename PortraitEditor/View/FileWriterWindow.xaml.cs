﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PortraitEditor.View
{
    /// <summary>
    /// Interaction logic for FileWriterWindow.xaml
    /// </summary>
    public partial class FileWriterWindow : Window
    {
        public FileWriterWindow( object obj)
        {
            DataContext = obj;
            InitializeComponent();
        }
    }
}