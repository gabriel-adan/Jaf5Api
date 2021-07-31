using System;
using SharpArch.Domain.DomainModel;

namespace Domain
{
    public class HourTurn : Entity
    {
        public virtual TimeSpan Time { get; set; }
        public virtual int DayOfWeek { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual int Reserved { get; set; }
        public virtual int Requested { get; set; }
        public virtual int CampId { get; set; }
    }
}
