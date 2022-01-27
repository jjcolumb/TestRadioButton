using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.ExpressApp.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.ExpressApp.Editors;
using System;
using System.Windows.Forms;

namespace TestRadioButton.Module.Win.Editors
{
    [PropertyEditor(typeof(Enum), false)]
    public class RadioGroupEnumPropertyEditor : EnumPropertyEditor
    {
        EnumDescriptor enumDescriptor;

        public RadioGroupEnumPropertyEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model)
        {
            ImmediatePostData = model.ImmediatePostData;
        }

        protected override object CreateControlCore()
        {
            enumDescriptor = new EnumDescriptor(GetUnderlyingType());
            RadioGroup radioGroup = new RadioGroup();
            foreach (object enumValue in enumDescriptor.Values)
                radioGroup.Properties.Items.Add(new RadioGroupItem(enumValue, enumDescriptor.GetCaption(enumValue)));
            return radioGroup;
        }

        protected override RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemRadioGroup();
        }

        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            RepositoryItemRadioGroup repositoryItemRadioGroup = (RepositoryItemRadioGroup)item;
        }

    }
}
