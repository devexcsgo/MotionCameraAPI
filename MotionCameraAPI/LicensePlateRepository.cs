namespace MotionCameraAPI
{
    public class LicensePlateRepository
    {
        private int _nextId = 1;
        private readonly List<LicensePlate> _licensePlates = new List<LicensePlate>();

        public LicensePlateRepository()
        {
            //// Mock data
            //_licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "DW74810", Time = DateTime.Now });
            //_licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "BT24209", Time = DateTime.Now });
        }

        // Add

        // Get
        public LicensePlate GetById(int id)
        {
            return _licensePlates.FirstOrDefault(lp => lp.Id == id);
        }

        // Get all

        // Delete
        public LicensePlate? Remove(int id)
        {
            LicensePlate? licensePlate = GetById(id);
            if (licensePlate == null)
            {
                return null;
            }
            _licensePlates.Remove(licensePlate);
            return licensePlate;
        }

    }
}
