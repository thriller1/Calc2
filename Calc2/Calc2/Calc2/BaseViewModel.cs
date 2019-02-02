using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileBillSoft.UiLayer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string BASE_VIEW_MODEL_TAG = "BaseViewModel";

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public delegate Task<bool> MessageAvailableEventHandler(object sender, string title, string message);
        public event MessageAvailableEventHandler MessageAvailable;

        protected async Task<bool> NotifyMessage(object sender, string title, string message)
        {
            try
            {   
                MessageAvailableEventHandler handler = MessageAvailable;
                if(handler != null)
                {
                    return await MessageAvailable(sender, title, message);
                }
            }
            catch (Exception ex)
            {
                //MbsLogger.Instance.Error(BASE_VIEW_MODEL_TAG, "NotityMessage Failed", ex);
            }
            return false;
        }

        protected async Task<bool> NotifyMessageFG(object sender, string title, string message)
        {
            try
            {
                MessageAvailableEventHandler handler = MessageAvailable;
                if (handler != null)
                {
                    Device.BeginInvokeOnMainThread(() => MessageAvailable(sender, title, message));
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MbsLogger.Instance.Error(BASE_VIEW_MODEL_TAG, "NotityMessage Failed", ex);
            }
            return false;
        }


        public delegate Task<bool> InputRequiredEventHandler(object context, int inputId, ICommand targetCommand);
        public event InputRequiredEventHandler InputRequired;

        protected async Task<bool> NotityInputRequired(object context, int inputId, ICommand targetCommand)
        {
            try
            {
                InputRequiredEventHandler handler = InputRequired;
                if (handler != null)
                {
                    Device.BeginInvokeOnMainThread(async () => await InputRequired(context, inputId, targetCommand));
                    return true;
                }
            }
            catch(Exception ex)
            {
                //MbsLogger.Instance.Error(BASE_VIEW_MODEL_TAG, "NotityInputRequired Failed", ex);                
            }
            return false;

        }
    }
}
