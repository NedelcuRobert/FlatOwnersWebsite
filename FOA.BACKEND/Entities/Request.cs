using FOA.BACKEND.Entities.Enums;

namespace FOA.BACKEND.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public RequestPriority Priority { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public RequestType Type { get; set; }
        public bool IsActive { get; set; }
    }
}
