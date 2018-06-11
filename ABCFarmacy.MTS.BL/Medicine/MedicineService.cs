using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web.Hosting;
using System.Linq;

namespace ABCFarmacy.MTS.BL.Medicine
{
    enum StatusCodes
    {
        Success= 1,
        Duplicate = 2,
        Error = 3
    }
    public class MedicineService : IMedicineService
    {
        private const string MEDICINE_STORE_PATH = @"E:/Demo Projects/Sapient/ABCFarmacy.MTS.API/ABCFarmacy.MTS.BL/MedicineStore/Medicines.json";
        public int AddMedicine(JObject medicineEntity)
        {
            try
            {
                if (medicineEntity == null)
                    return Convert.ToInt16(StatusCodes.Error);
                var json = File.ReadAllText(MEDICINE_STORE_PATH);
                var medicineStore = JArray.Parse(json);

                var isExists = medicineStore.Where(x => x["MedicineName"].Value<string>().Equals(medicineEntity["MedicineName"].Value<string>())).Any();
                if (!isExists)
                {
                    medicineStore.Add(medicineEntity);
                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(medicineStore, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(MEDICINE_STORE_PATH, newJsonResult);
                    return Convert.ToInt16(StatusCodes.Success);
                }
                else
                {
                    return Convert.ToInt16(StatusCodes.Duplicate); ;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public string GetAllMedicine()
        {           
            try
            {
                var json = File.ReadAllText(MEDICINE_STORE_PATH);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetMedicineById(string medicineId)
        {
            try
            {
                var json = File.ReadAllText(MEDICINE_STORE_PATH);
                var medicineStore = JArray.Parse(json);
                var medicine = medicineStore.Where(x => x["MedicineId"].Value<string>().Equals(medicineId)).SingleOrDefault();
                return Convert.ToString(medicine);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateMedicine(string medicineId, JObject medicineEntity)
        {
            throw new NotImplementedException();
        }
    }
}
