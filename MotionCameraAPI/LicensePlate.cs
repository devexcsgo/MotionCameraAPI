namespace MotionCameraAPI
{
    public class LicensePlate
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public DateTime? Time { get; set; }
        public string? ImagePath { get; set; } // Property to store the image file path

        public override string ToString()
        {
            return $"Id: {Id}, Plate: {Plate}, Time: {Time:dd-MM-yyyy HH:mm:ss}";
        }

        // Checks if the string of plates are to long or short.
        // The sting needs to exactly 7 characters long.
        public void ValidatePlate()
        {
            if (Plate == null)
            {
                throw new ArgumentNullException("License plate can't be null");
            }
            if (Plate.Length < 7 || Plate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("Plate string to short or long. Need to be 7 long");
            }
        }
    }
}