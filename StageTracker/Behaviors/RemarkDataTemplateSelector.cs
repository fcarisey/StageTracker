using System.Windows;
using System.Windows.Controls;

namespace StageTracker.Behaviors;

public class RemarkDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate ReadOnlyTemplate { get; set; } = default!;
    public DataTemplate WriteTemplate { get; set; } = default!;

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is Models.Remark remark)
            return (remark.IsEditing) ? WriteTemplate : ReadOnlyTemplate;

        // Fallback to a default template if no match is found
        return base.SelectTemplate(item, container);
    }
}
