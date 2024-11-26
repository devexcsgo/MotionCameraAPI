namespace MotionCameraAPI
{
    public class LicensePlateRepository
    {
        private int _nextId = 1;
        private readonly List<LicensePlate> _licensePlates = new List<LicensePlate>();

        public LicensePlateRepository()
        {
            // Mock data
            _licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "ABC123", Time = DateTime.Now });
            _licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "DEF456", Time = DateTime.Now });
        }

        // Add

        // Get

        // Get all

        // Delete

    }
}
