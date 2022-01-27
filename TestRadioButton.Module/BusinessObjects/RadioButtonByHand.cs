using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TestRadioButton.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class RadioButtonByHand : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public RadioButtonByHand(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Option1 = true;
        }

        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        string phone;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }


        bool option1;
        [ImmediatePostData]
        public bool Option1
        {
            get => option1;
            set => SetPropertyValue(nameof(Option1), ref option1, value);
        }

        bool option2;
        [ImmediatePostData]
        public bool Option2
        {
            get => option2;
            set => SetPropertyValue(nameof(Option2), ref option2, value);
        }

        bool option3;
        [ImmediatePostData]
        public bool Option3
        {
            get => option3;
            set => SetPropertyValue(nameof(Option3), ref option3, value);
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (!IsLoading)
            {
                if (propertyName == nameof(Option1) && (bool)newValue)
                {
                    Option2 = false;
                    RaisePropertyChangedEvent(nameof(Option2));
                    option3 = false;
                    RaisePropertyChangedEvent(nameof(Option3));
                }
                else if (propertyName == nameof(Option2) && (bool)newValue)
                {
                    Option1 = false;
                    RaisePropertyChangedEvent(nameof(Option1));
                    option3 = false;
                    RaisePropertyChangedEvent(nameof(Option3));
                }
                else if (propertyName == nameof(Option3) && (bool)newValue)
                {
                    Option1 = false;
                    RaisePropertyChangedEvent(nameof(Option1));
                    option2 = false;
                    RaisePropertyChangedEvent(nameof(Option2));
                }
            }
        }
    }
}