﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using Ookii.Dialogs.Wpf;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortraitEditor.ViewModel;
using PortraitEditor.View;
using PortraitEditor.JsonHandling;
using PortraitEditor.ViewModel.SubWindows;
using PortraitEditor.Model;
using PortraitEditor.Model.SSFiles;

namespace PortraitEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        public SSFactionDirectory FactionDirectory { get; set; } = new SSFactionDirectory();

        public SSMod LPeSSMod { get;} = new SSMod() { Name = "LPeSS" };
        //public SSFileExplorerViewModel FileExplorer { get; set; } = new SSFileExplorerViewModel();
        //public SSPortraitExplorerViewModel PortraitExplorer { get; set; }

        //public SSFileWriterViewModel FileWriter { get; set; }
        //public SSMod L_PessMod { get; set; }

        ICommand _ExploreFileCommand;
        public ICommand ExploreFileCommand
        {
            get
            {
                if (_ExploreFileCommand == null)
                {
                    _ExploreFileCommand = new RelayCommand<object>(param => this.ExploreFiles());
                }
                return _ExploreFileCommand;
            }
        }

        ICommand _ExplorePortraitCommand;
        public ICommand ExplorePortraitCommand
        {
            get
            {
                if (_ExplorePortraitCommand == null)
                {
                    _ExplorePortraitCommand = new RelayCommand<object>(param => this.ExplorePortraits());
                }
                return _ExplorePortraitCommand;
            }
        }
        ICommand _WriteFileCommand;
        public ICommand WriteFileCommand
        {
            get
            {
                if (_WriteFileCommand == null)
                {
                    _WriteFileCommand = new RelayCommand<object>(param => this.WriteFiles());
                }
                return _WriteFileCommand;
            }
        }
        ICommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new RelayCommand<object>(param => CloseWindow());
                }
                return _CloseCommand;
            }
        }


        public MainWindow()
        {
            //FileExplorer.ShowDialog();
            //PortraitExplorer = new SSPortraitExplorerViewModel(FileExplorer.FactionDirectory,FileExplorer.LPeSSMod);
            //PortraitExplorer.ShowDialog();
            //L_PessMod = FileExplorer.LPeSSMod;
            //PortraitExplorer = new SSPortraitExplorerViewModel(FactionDirectory, LPeSSMod);
            //FileWriter = new SSFileWriterViewModel(LPeSSMod, FactionDirectory);
            DataContext = this;
            InitializeComponent();
        }


 
       
        private void ExploreFiles()
        {
            //this.Hide();
            //FileExplorer.ShowDialog();
            //this.Show();
            return;
        }
        private void ExplorePortraits()
        {
            //this.Hide();
            //PortraitExplorer.LocalMod = LPeSSMod;
            //PortraitExplorer.ShowDialog();
            //this.Show();
            return;
        }
        private void WriteFiles()
        {
            //this.Hide();
            //FileWriter.L_PeSSMod = FileExplorer.LPeSSMod;
            //FileWriter.ShowDialog();
            //this.Show();
        }
        private void CloseWindow()
        {
            this.Close();
        }

    }
 

    




}
