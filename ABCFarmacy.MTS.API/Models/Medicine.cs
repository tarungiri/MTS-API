using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCFarmacy.MTS.API.Models
{
    public class Medicine
    {
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }

        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}