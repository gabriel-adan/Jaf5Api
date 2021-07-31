using System;

namespace Logic.Dtos
{
    public class HourDto : EntityDto
    {
        public TimeSpan Time { get; set; }
        public int DayOfWeek { get; set; }
        public bool IsEnabled { get; set; }
        public int CampId { get; set; }

        public HourDto(int id, TimeSpan time, int dayOfWeek, bool isEnabled, int campId) : base (id)
        {
            Time = time;
            DayOfWeek = dayOfWeek;
            IsEnabled = isEnabled;
            CampId = campId;
        }
    }
}
