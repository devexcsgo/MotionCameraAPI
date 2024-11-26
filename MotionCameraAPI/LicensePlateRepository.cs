namespace MotionCameraAPI
{
    public class LicensePlateRepository
    {
        private int _nextId = 1;
        private readonly List<LicensePlate> _licensePlates = new List<LicensePlate>();
    }
}
