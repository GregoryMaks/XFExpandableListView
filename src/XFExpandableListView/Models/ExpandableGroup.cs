using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XFExpandableListView.Abstractions;
using Xamarin.Forms;
using System.Windows.Input;

namespace XFExpandableListView.Models
{
    /// <inheritdoc cref="ObservableCollection{T}" />
    /// <summary>
    /// Base Class for the Group Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpandableGroup<T> : ObservableCollection<T>, IExpandableGroup
    {
        public Guid Id { get; set; }

        private bool _isExpandable;
        public bool IsExpandable
        {
            get => _isExpandable;
            set
            {
                if (_isExpandable == value) return;
                _isExpandable = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsExpandable)));
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded == value) return;
                _isExpanded = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsExpanded)));
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public ICommand CellTappedCommand { get; set; }

        public event EventHandler<ToggleExpandEventArgs> ToggleExpandedState;

        public ExpandableGroup(Guid id, string title)
        {
            Id = id;
            CellTappedCommand = new Command((obj) =>
            {
                if (IsExpandable)
                {
                    ToggleExpandedState?.Invoke(this, new ToggleExpandEventArgs { NewExpandableState = !IsExpanded } );
                }
            });
        }

        public virtual IExpandableGroup NewInstance()
        {
            return new ExpandableGroup<T>(Id, Title);
        }
    }
}
