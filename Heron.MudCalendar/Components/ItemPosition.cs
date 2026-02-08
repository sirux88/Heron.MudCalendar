using System.Diagnostics.CodeAnalysis;

namespace Heron.MudCalendar;

public class ItemPosition<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>  where T : CalendarItem
{
    public T Item { get; set; } = (T)Activator.CreateInstance(typeof(T))!;
    public int Position { get; set; }
    public int Total { get; set; }
    public DateOnly Date { get; set; }
    public double Top { get; set; }
    public double Left { get; set; }
    public double Height { get; set; }
    public double Width { get; set; } = 1;
    public double Bottom => Top + Height;
}