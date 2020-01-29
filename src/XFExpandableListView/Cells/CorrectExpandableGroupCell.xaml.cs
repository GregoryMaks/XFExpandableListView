using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFExpandableListView.Abstractions;

namespace XFExpandableListView.Cells
{
    public partial class CorrectExpandableGroupCell : ViewCell
    {
        private IExpandableGroup ViewModel => BindingContext as IExpandableGroup;
        private IExpandableController ExpandableController => Parent as IExpandableController;

        public CorrectExpandableGroupCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}
