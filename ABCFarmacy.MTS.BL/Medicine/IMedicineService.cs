using Newtonsoft.Json.Linq;
using System;

namespace ABCFarmacy.MTS.BL.Medicine
{
    public interface IMedicineService
    {
        string GetMedicineById(string medicineId);
        string GetAllMedicine();
        int AddMedicine(JObject medicineEntity);
        int UpdateMedicine(string medicineId, JObject medicineEntity);
    }
}
