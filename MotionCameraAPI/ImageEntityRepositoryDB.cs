namespace MotionCameraAPI
{
    public class ImageEntityRepositoryDB
    {
        private ImageEntityDbContext _context;

        public ImageEntityRepositoryDB(ImageEntityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ImageEntity> GetAll()
        {
            return _context.Images.ToList();
        }

        public ImageEntity Get(int id)
        {
            return _context.Images.FirstOrDefault(x => x.Id == id);
        }

        public ImageEntity Add(ImageEntity newImageEntity)
        {
            _context.Images.Add(newImageEntity);
            _context.SaveChanges();
            return newImageEntity;
        }

        public ImageEntity Remove(int id)
        {
            ImageEntity imageEntity = Get(id);
            if (imageEntity == null)
            {
                return null;
            }
            _context.Images.Remove(imageEntity);
            _context.SaveChanges();
            return imageEntity;
        }
    }
}
