using FOA.BACKEND.Entities.Enums;

namespace FOA.BACKEND.Business.DTO
{
    public class RequestDTO
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public RequestPriority Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
