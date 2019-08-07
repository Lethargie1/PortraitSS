﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortraitEditor.Model.SSFiles
{
    //a directory of group of files.
    public class SSFileDirectory<G, F> where G : SSFileGroup<F> where F : SSFile
    {

        SSFileLister<G> _GroupDirectory = new SSFileLister<G>();
        public ObservableCollection<G> GroupDirectory { get => _GroupDirectory.Files; }

        public List<string> AvailableLinkingUrl = new List<string>();

        public void AddFile(F newFile)
        {
            string newFileLink = newFile.Url.LinkingUrl;
            if (!AvailableLinkingUrl.Contains(newFileLink))
                AvailableLinkingUrl.Add(newFileLink);
            G Matching = (from fileGroup in GroupDirectory
                    where fileGroup.FileName == newFile.FileName
                    select fileGroup).SingleOrDefault();

            if (Matching != null)
                Matching.Add(newFile);
            else
            {
                G newGroup = Activator.CreateInstance(typeof(G), new Object[] { newFile , AvailableLinkingUrl}) as G;
                GroupDirectory.Add(newGroup);
            }
            return;
        }
        public void AddRange(List<F> FileList)
        {
            foreach (F newFile in FileList)
            {
                this.AddFile(newFile);
            }
        }


        public void DeleteDirectory()
        {
            _GroupDirectory.Delete();
        }
    }
}
