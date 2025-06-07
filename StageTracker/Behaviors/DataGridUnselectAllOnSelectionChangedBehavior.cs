using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;


namespace StageTracker.Behaviors;

class DataGridUnselectAllOnSelectionChangedBehavior : Behavior<DataGrid>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.SelectionChanged += OnSelectionChanged;
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.SelectionChanged -= OnSelectionChanged;
    }
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (AssociatedObject.SelectedItems.Count > 0)
        {
            AssociatedObject.UnselectAll();
        }
    }
}