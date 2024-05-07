
using System;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Scaffolders.Models.Grid
{
    using System;
    
    public class GridModel
    {
        [Editable(false)]
        public int Id { get; set; }
     
        public double Freight
        {
            get;
            set;
        }

        [Required]
        public DateTime? OrderDate
        {
            get;
            set;
        }

        public string ShipCity
        {
            get;
            set;
        }

        public string ShipName
        {
            get;
            set;
        }
    }
}

