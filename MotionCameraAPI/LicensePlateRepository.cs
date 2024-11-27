namespace MotionCameraAPI
{
    public class LicensePlateRepository : ILicensePlateRepository
    {
        private int _nextId = 1;
        private readonly List<LicensePlate> _licensePlates = new List<LicensePlate>();

        public LicensePlateRepository()
        {
            //_licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "DW74810", Time = DateTime.Now });
            //_licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "BT24209", Time = DateTime.Now });
        }

        public void MockData()
        {
            if (_licensePlates.Count == 0)
            {
                _licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "DW74810", Time = DateTime.Now });
                _licensePlates.Add(new LicensePlate { Id = _nextId++, Plate = "BT24209", Time = DateTime.Now });
            }
        }

        // Add
        public LicensePlate Add(LicensePlate licensePlate)
        {
            licensePlate.ValidatePlate();
            licensePlate.Id = _nextId++;
            _licensePlates.Add(licensePlate);
            return licensePlate;
        }

        // Get
        public LicensePlate Get(int id)
        {
            return _licensePlates.FirstOrDefault(lp => lp.Id == id);
        }

        // Get all
        public IEnumerable<LicensePlate> GetAll()
        {
            IEnumerable<LicensePlate> allPlatesList = new List<LicensePlate>(_licensePlates);
            return allPlatesList;
        }

        // Delete
        public LicensePlate? Remove(int id)
        {
            LicensePlate? licensePlate = Get(id);
            if (licensePlate == null)
            {
                return null;
            }
            _licensePlates.Remove(licensePlate);
            return licensePlate;
        }

    }
}
