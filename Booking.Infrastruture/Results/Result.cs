namespace Booking.Infrastruture.Results
{
    public class Result<T> : ErrorableResult
    {
        public Result(IEnumerable<string> errors, T data, bool success) : base(errors, success)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
