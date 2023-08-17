using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Results
{
    public class ErrorableResult
    {
        public ErrorableResult(IEnumerable<string> errors, bool success)
        {
            Errors = errors;
            Success = success;
        }
        public ErrorableResult(string error, bool success)
        {
            Errors = new List<string>() { error };
            Success = success;
        }

        public IEnumerable<string> Errors { get; set; }
        public bool Success { get; set; }

        public static ErrorableResult OK { get; private set; } = new ErrorableResult(new List<string>(), true);
    }
}
