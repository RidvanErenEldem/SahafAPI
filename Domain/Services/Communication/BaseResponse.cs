namespace SahafAPI.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }

        protected BaseResponse(bool Success, string Message)
        {
            this.success = Success;
            this.message = Message;
        }
    }
}