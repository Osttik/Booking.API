namespace Booking.Infrastruture.Results
{
    public class ListResult<T> : Result<IEnumerable<T>>
    {
        public ListResult(IEnumerable<string> errors, IEnumerable<T> data, bool success, int totalElements, int currentPage, int numberOfElements) : base(errors, data, success)
        {
            TotalElements = totalElements;
            CurrentPage = currentPage;
            NumberOfElements = numberOfElements;
        }

        /// <summary>
        /// Count of elements in db
        /// </summary>
        public int TotalElements { get; set; }
        public int CurrentPage { get; set; }
        /// <summary>
        /// Count of elements on page
        /// </summary>
        public int NumberOfElements { get; set; }
    }
}
