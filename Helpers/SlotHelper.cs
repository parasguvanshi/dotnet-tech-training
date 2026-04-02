using SportsManagementApp.Exceptions;
using SportsManagementApp.StringConstants;

namespace SportsManagementApp.Helpers
{
    public static class SlotHelper
    {
        public static DateTime GetNextSlot(DateTime current, DateOnly endDate)
        {
            var nextSlotStart = current.AddMinutes(StringConstant.SlotMinutes);

            if (TimeOnly.FromDateTime(nextSlotStart) >= StringConstant.DayEnd)
                nextSlotStart = nextSlotStart.Date.AddDays(1).Add(StringConstant.DayStart.ToTimeSpan());

            if (DateOnly.FromDateTime(nextSlotStart) > endDate)
                throw new BadRequestException(StringConstant.NotEnoughDaysToSchedule);

            return nextSlotStart;
        }
    }
}