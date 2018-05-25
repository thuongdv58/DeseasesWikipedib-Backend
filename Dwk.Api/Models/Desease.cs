using System;
using System.Collections.Generic;

namespace Dwk.Api.Models
{
    public class Desease
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string @abstract { get; set; }
        //public virtual ICollection<User> Patients { get; set; }
        public string attributes { get; set; }
    }
}
