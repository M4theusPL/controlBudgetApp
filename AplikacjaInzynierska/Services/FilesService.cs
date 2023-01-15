using AplikacjaInzynierska.Data;

namespace AplikacjaInzynierska.Services
{
    //public interface IFilesService
    //{
    //    List<FilesClass> GetFiles();
    //    FilesClass Save (FilesClass file);
    //    FilesClass Upload(byte[] data);
    //    void Delete(id_file);

        
    //}

    public class FilesService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public FilesService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }
        
        public void DeletePdf(int id_file)
        {
            _dbcontext.files.SingleOrDefault(x=>x.id_file == id_file).attachment = null;
            _dbcontext.SaveChanges();
        }
        public List<FilesClass> GetFiles()
        {
            return _dbcontext.files.ToList();
        }

        public FilesClass SavePdf(FilesClass file)
        {
            _dbcontext.files.Add(file);
            _dbcontext.SaveChanges();
            return file;
        }

        public FilesClass UploadPdf (int id_file, byte[] data)
        {
            _dbcontext.files.SingleOrDefault(x=>x.id_file == id_file).attachment = data;
            _dbcontext.SaveChanges();
            return _dbcontext.files.SingleOrDefault(x => x.id_file == id_file);
        }

        public async Task<bool> AddNewFile(FilesClass file)
        {
            _dbcontext.files.Add(file);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public FilesClass? GetByFile(int id_file)
        {
            return _dbcontext.files.FirstOrDefault(x => x.id_file == id_file);
        }
    }
}
