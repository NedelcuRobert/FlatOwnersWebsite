using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IAnnouncementService
    {
        Task<List<Announcement>> GetAllAnnouncementsAsync();
        Task<Announcement> GetAnnouncementByIdAsync(int announcementId);
        Task<Announcement> CreateAnnouncementAsync(Announcement announcement);
        Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
        Task DeleteAnnouncementAsync(int announcementId);
    }
}
