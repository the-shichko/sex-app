using System;
using System.Collections.Generic;
using System.Linq;

namespace sex_app.Models
{
    public class ApplicationCouple
    {
        public Guid Id { get; set; }
        public long FirstPartner { get; set; }
        public long SecondPartner { get; set; }
    }

    public class ApplicationCouples : List<ApplicationCouple>
    {
        /// <summary>
        /// Get couple by id (Any partner identifier) 
        /// </summary>
        /// <param name="id">Any partner identifier</param>
        public ApplicationCouple this[long id] =>
            this.FirstOrDefault(x => x.FirstPartner == id || x.SecondPartner == id);
    }
}