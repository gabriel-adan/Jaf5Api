using Logic.Dtos;
using System.Collections.Generic;

namespace Logic.Contracts
{
    public interface ICampLogic
    {
        CampDto Create(string email, string name, string street, string number, double longitude, double latitude, IList<string> fieldNames, int fieldCount);

        IList<FieldDto> GetFields(int campId);

        void EditFieldState(int fieldId, int campId, bool isEnabled);

        IList<CampDto> ListByBufferZone(double longitude, double latitude, float radius);

        IList<CampDto> List(string userName);
    }
}
