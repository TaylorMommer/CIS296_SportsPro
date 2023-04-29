using System.Collections.Generic;

namespace SportsPro.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all"; 
            
            string[] filters = FilterString.Split('-'); TechnicianID = filters[0]; ClosedDate = filters[1]; StatusId = filters[2];
        }
        public string FilterString { get; }
        public string TechnicianID { get; }
        public string ClosedDate { get; }
        public string StatusId { get; }
        public bool HasTechnician => TechnicianID.ToLower() != "all"; 
        public bool HasClosed => ClosedDate.ToLower() != "all"; 
        public bool HasStatus => StatusId.ToLower() != "all";
    };
}


