﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortraitEditor.JsonHandling;
using PortraitEditor.Model;
using PortraitEditor.Model.SSParameters;
using PortraitEditor.Model.SSFiles;
using PortraitEditor.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PortraitEditor.ViewModel.SubWindows
{
    public class SSFileWritterViewModel : ViewModelBase
    {
        #region Constructor
        public SSFileWritterViewModel(SSMod l_PeSSMod, SSFactionDirectory factionDirectory)
        {
            L_PeSSMod = l_PeSSMod;
            FactionDirectory = factionDirectory;

        }
        #endregion


        #region field
        FileWriterWindow WindowView;
        ObservableCollection<SSFactionGroup> _ModifiedFactionList;
        string FactionFolderPath;
        string PortraitGraphPath;
        JObject ModInfo = new JObject(
                            new JProperty("id", "l_pess"),
                            new JProperty("name", "Lethargie portrait editor for Starsector"),
                            new JProperty("author", "Lethargie"),
                            new JProperty("version", "v1.0"),
                            new JProperty("description", "Add some portraits"),
                            new JProperty("gameVersion", "0.9.1a"));
        #endregion


        #region properties
        public SSMod L_PeSSMod { get; set; }
        public SSFactionDirectory FactionDirectory { get; set; }
        public ObservableCollection<SSFactionGroup> ModifiedFactionList
        {
            get
            {

                _ModifiedFactionList = new ObservableCollection<SSFactionGroup>(from factionGroup in FactionDirectory.GroupDirectory
                                                                                         where factionGroup.BufferedPortraits
                                                                                         select factionGroup);
                return _ModifiedFactionList;
            }
        }
        #endregion


        #region Show Associated view
        public void ShowDialog()
        {

            if (L_PeSSMod.Url.CommonUrl == null)
                throw new DirectoryNotFoundException();
            FactionFolderPath = Path.Combine(new string[4] { L_PeSSMod.Url.FullUrl, "data", "world", "factions" });
            PortraitGraphPath = Path.Combine(new string[4] { L_PeSSMod.Url.FullUrl, "graphics", "LPESS", "portraits" });
            WindowView = new FileWriterWindow(this);
            WindowView.ShowDialog();
            return;
        }
        #endregion

        #region Commands
        RelayCommand<object> _AppendFilesCommand;
        public ICommand AppendFilesCommand
        {
            get
            {
                if (_AppendFilesCommand == null)
                {
                    _AppendFilesCommand = new RelayCommand<object>(param => this.WriteAppend());
                }
                return _AppendFilesCommand;
            }
        }
        RelayCommand<object> _CopyImagesToModCommand;
        public ICommand CopyImagesToModCommand
        {
            get
            {
                if (_CopyImagesToModCommand == null)
                {
                    _CopyImagesToModCommand = new RelayCommand<object>(param => this.CopyImagesToMod());
                }
                return _CopyImagesToModCommand;
            }
        }
        #endregion
        public void ClearModFolder()
        {
            DirectoryInfo LPeSSFactionDirectory = new DirectoryInfo(L_PeSSMod.Url.FullUrl);
            if (!LPeSSFactionDirectory.Exists)
                LPeSSFactionDirectory.Create();
            DirectoryInfo FactionFolderInfo = new DirectoryInfo(FactionFolderPath);
            if (!FactionFolderInfo.Exists)
                FactionFolderInfo.Create();
            else
            {
                List<FileInfo> ExistingFiles = FactionFolderInfo.EnumerateFiles().ToList();
                for (int i = ExistingFiles.Count() - 1; i > 0; i++)
                {
                    ExistingFiles[i].Delete();
                }
            }
            FactionFolderInfo = new DirectoryInfo(PortraitGraphPath);
            if (!FactionFolderInfo.Exists)
                FactionFolderInfo.Create();

            using (JsonTextWriter writer = new JsonTextWriter(File.CreateText(Path.Combine(L_PeSSMod.Url.FullUrl, "mod_info.json"))))
            {
                writer.Formatting = Formatting.Indented;
                ModInfo.WriteTo(writer);
            }

        }
        public void WriteAppend()
        {
            //ClearModFolder();
            //foreach (SSFactionGroupViewModel vm in ModifiedFactionList)
            //{
            //    var PossiblePortrait = from portrait in vm.AddedPortraits
            //                           where portrait.Url.IsComplete
            //                           select portrait;
            //    JObject AppendPortrait = PossiblePortrait.FlattenToJson();
            //    using (StreamWriter file = File.CreateText(Path.Combine(FactionFolderPath, vm.FactionGroupModel.FileName)))
            //    {
            //        using (JsonTextWriter writer = new JsonTextWriter(file))
            //        {
            //            writer.Formatting = Formatting.Indented;
            //            AppendPortrait.WriteTo(writer);
            //        }
            //    }
            //}
        }
        public void CopyImagesToMod()
        {
            //DirectoryInfo FactionFolderInfo = new DirectoryInfo(PortraitGraphPath);
            //if (!FactionFolderInfo.Exists)
            //    FactionFolderInfo.Create();
            //foreach (SSFactionGroupViewModel vm in ModifiedFactionList)
            //{
            //    var PossiblePortrait = from portrait in vm.AddedPortraits
            //                           where !portrait.Url.IsComplete
            //                           select portrait;
            //    foreach (SSPortrait portrait in PossiblePortrait)
            //    {

            //        FileInfo newfile = new FileInfo(portrait.Url.FullUrl);
            //        string newRelativePath = Path.Combine(new string[4] { "graphics", "LPESS", "portraits", newfile.Name });
            //        URLRelative newUrl = new URLRelative()
            //        {
            //            CommonUrl = L_PeSSMod.Url.CommonUrl,
            //            LinkingUrl = L_PeSSMod.Url.LinkingUrl,
            //            RelativeUrl = newRelativePath
            //        };
            //        FileInfo checkFile = new FileInfo(newUrl.FullUrl);
            //        if (checkFile.Exists)
            //            checkFile.Delete();
            //        newfile.CopyTo(newUrl.FullUrl);
            //        portrait.Url = newUrl;
            //    }

            //}
        }
    }
    public class CollectionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is ICollection))
                return Visibility.Collapsed;
            if ((value as ICollection).Count > 0)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

