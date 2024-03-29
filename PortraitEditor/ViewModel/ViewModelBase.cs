﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PortraitEditor.ViewModel
{
    public abstract class  ViewModelBase : INotifyPropertyChanged //, IDisposable
    {
        #region Constructor

        protected ViewModelBase()
        {
        }

        #endregion // Constructor

        #region Debugging Aides

        ///// <summary>
        ///// Warns the developer if this object does not have
        ///// a public property with the specified name. This 
        ///// method does not exist in a Release build.
        ///// </summary>
        //[Conditional("DEBUG")]
        //[DebuggerStepThrough]
        //public void VerifyPropertyName(string propertyName)
        //{
        //    // Verify that the property name matches a real,  
        //    // public, instance property on this object.
        //    if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        //    {
        //        string msg = "Invalid property name: " + propertyName;

        //        if (this.ThrowOnInvalidPropertyName)
        //            throw new Exception(msg);
        //        else
        //            Debug.Fail(msg);
        //    }
        //}

        ///// <summary>
        ///// Returns whether an exception is thrown, or if a Debug.Fail() is used
        ///// when an invalid property name is passed to the VerifyPropertyName method.
        ///// The default value is false, but subclasses used by unit tests might 
        ///// override this property's getter to return true.
        ///// </summary>
        //protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion

        //#region IDisposable Members

        ///// <summary>
        ///// Invoked when this object is being removed from the application
        ///// and will be subject to garbage collection.
        ///// </summary>
        //public void Dispose()
        //{
        //    this.OnDispose();
        //}

        ///// <summary>
        ///// Child classes can override this method to perform 
        ///// clean-up logic, such as removing event handlers.
        ///// </summary>
        //protected virtual void OnDispose()
        //{
        //}

        //#endregion 
    }
}
