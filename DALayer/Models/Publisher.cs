using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
