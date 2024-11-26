namespace MotionCameraAPI
{
    public class LicensePlate
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public DateTime? Time { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Plate: {Plate}, Time: {Time}";
        }
        public void ValidatePlate()
        {
            if (Plate == null)
            {
                throw new Exception("Plate is null");
            }
        }

    }
}
