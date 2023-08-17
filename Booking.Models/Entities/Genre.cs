using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class Genre
    {
        /// <summary>
        /// Name of type of genre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// All related genre movies
        /// </summary>
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
