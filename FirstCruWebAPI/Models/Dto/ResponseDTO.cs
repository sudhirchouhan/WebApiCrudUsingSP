namespace Mango.Services.CouponApi.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result {  get; set; }
        public Boolean IsSuccess { get; set; } = true;
        public string Message { get; set; } = " ";
    }
}
