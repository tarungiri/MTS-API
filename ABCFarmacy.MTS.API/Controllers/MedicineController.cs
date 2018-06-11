using ABCFarmacy.MTS.BL.Medicine;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ABCFarmacy.MTS.API.Controllers
{
    public class MedicineController : ApiController
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        [HttpGet]
        public HttpResponseMessage GetMedicines()
        {
            var medicines = _medicineService.GetAllMedicine();
            if (medicines != null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(medicines, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No medicines found");
        }
        [HttpGet]
        public HttpResponseMessage GetMedicine(string id)
        {
            var medicine = _medicineService.GetMedicineById(id);
            if (medicine != null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(medicine, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No medicine found for this id");
        }
        [HttpPost]
        public HttpResponseMessage AddMedicine([FromBody]JObject medicine)
        {
            var newMedicine = _medicineService.AddMedicine(medicine);
            if (newMedicine == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, newMedicine);
            }
            else if(newMedicine == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Ambiguous, "Record with same name already exists");
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "New medicine insertion failed.");
        }
        [HttpPut]
        public HttpResponseMessage UpdateMedicine(string id, [FromBody]JObject medicine)
        {
            var updatedMedicine = _medicineService.UpdateMedicine(id, medicine);
            if (updatedMedicine == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, updatedMedicine);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Medicine updation failed.");
        }
        
    }
}
