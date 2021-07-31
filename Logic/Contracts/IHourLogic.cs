using System;
using System.Collections.Generic;
using Logic.Dtos;

namespace Logic.Contracts
{
    public interface IHourLogic
    {
        HourDto Create(TimeSpan time, int dayOfWeek, bool isEnabled, int campId);

        void EnableDisable(int hourId, bool isEnabled);

        IList<HourDto> List(int campId);
    }
}
