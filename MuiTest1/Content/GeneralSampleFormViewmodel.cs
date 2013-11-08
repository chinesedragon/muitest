using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuiTest1.Content
{
    public class GeneralSampleFormViewmodel : NotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName = "John";

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
            OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value;
            OnPropertyChanged("LastName");
            }
        }


        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get {
                if (columnName == "FirstName")
                {
                    return string.IsNullOrWhiteSpace(firstName) ? "Required Value" : null;
                }
                if (columnName == "LastName")
                {
                    return string.IsNullOrWhiteSpace(lastName) ? "Required Value" : null;
                }
                return null;
            }
        }
    }
}
