namespace MotionCameraAPI
{
        public interface ILicensePlateRepository
        {
            LicensePlate Add(LicensePlate licensePlate);
            IEnumerable<LicensePlate> GetAll();
            LicensePlate? Get(int id);
            LicensePlate? Remove(int id);
        }   
}
