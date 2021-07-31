namespace Logic.Dtos
{
    public class FieldDto : EntityDto
    {
        public string Name { get; }
        public bool IsEnabled { get; }
        public int CampId { get; }

        public FieldDto(int id, bool isEnabled, int campId) : base (id)
        {
            IsEnabled = isEnabled;
            CampId = campId;
        }
    }
}
