using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopSivadi.Core.Domain;
using TARpe21ShopSivadi.Core.Dto;
using TARpe21ShopSivadi.Core.ServiceInterface;
using TARpe21ShopSivadi.Data;

namespace TARpe21ShopSivadi.ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        private readonly TARpe21ShopSivadiContext _context;
        public FilesServices
            (
                TARpe21ShopSivadiContext context
            )
        {
            _context = context;
        }
        public void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var image = await _context.FileToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();
            _context.FileToDatabase.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.FileToDatabase
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefaultAsync();

                _context.FileToDatabase.Remove(image);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
