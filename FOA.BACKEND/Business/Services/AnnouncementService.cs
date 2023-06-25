using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Announcement, int> _announcementRepository;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _announcementRepository = unitOfWork.AnnouncementRepository;
        }

        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _announcementRepository.GetAll().ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(int announcementId)
        {
            return await _announcementRepository.GetByIdAsync(announcementId);
        }

        public async Task<Announcement> CreateAnnouncementAsync(Announcement announcement)
        {
            await _announcementRepository.AddAsync(announcement);
            _unitOfWork.Save();

            return announcement;
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            var existingAnnouncement = await _announcementRepository.GetByIdAsync(announcement.Id);
            if (existingAnnouncement == null)
            {
                // Anunțul nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            // Actualizăm câmpurile anunțului existent cu valorile din anunțul actualizat
            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Message = announcement.Message;
            existingAnnouncement.User = announcement.User;
            existingAnnouncement.UserId = announcement.UserId;
            // Actualizează și alte câmpuri, după caz

            _announcementRepository.Update(existingAnnouncement);
            _unitOfWork.Save();

            return existingAnnouncement;
        }

        public async Task DeleteAnnouncementAsync(int announcementId)
        {
            await _announcementRepository.RemoveAsync(announcementId);
            _unitOfWork.Save();
        }
    }
}
