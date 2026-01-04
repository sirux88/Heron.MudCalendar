using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Heron.MudCalendar;

public class DayView<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T> : DayWeekViewBase<T> where T:CalendarItem
{
    protected override int DaysInView => 1;
    protected override CalendarView View => CalendarView.Day;
    //protected override string HeaderClassname => "mud-cal-day-header";
    //protected override string GridClassname => "mud-cal-week-grid";

    protected override List<CalendarCell<T>> BuildCells()
    {
        var cells = new List<CalendarCell<T>>();
        var date = Calendar.CurrentDay.Date;
        var lastDate = date.AddDays(1).AddTicks(-1);
        while (date <= lastDate)
        {
            var cell = new CalendarCell<T> { Date = date };
            if (date.Date == DateTime.Today) cell.Today = true;

            cell.Items = Calendar.Items.Where(i => i.Start >= date && i.Start < date.AddMinutes((int)Calendar.DayTimeInterval))
                    .OrderBy(i => i.Start)
                    .ToList();
            cells.Add(cell);

            // Next day
            date = date.AddMinutes((int)Calendar.DayTimeInterval);
        }
        
        return cells;
    }

    protected override RenderFragment<T> CellTemplate => Calendar.DayTemplate ?? Calendar.CellTemplate;
}
