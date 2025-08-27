using CarBook_OnionArch.Dto.FeaturesDtos;

namespace CarBook_OnionArch.Dto.CarFeatureDtos
{
    public class UpdateCarFeatureDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
        public ResultFeatureDto? Feature { get; set; }
    }
}
