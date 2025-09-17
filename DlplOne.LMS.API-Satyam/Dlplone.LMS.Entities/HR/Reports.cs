using System.Text.Json.Serialization;

namespace Dlplone.LMS.Entities.HR
{

    public class Extension
    {
        public string scheduledDate { get; set; }
        public string patientId { get; set; }
        public string collectLocation { get; set; }
        //public string category { get; set; }
        public string patientName { get; set; }
        //public string orderNo { get; set; }
        //public string source { get; set; }
        public string patientSex { get; set; }
        public string patientDob { get; set; }
        //public string performingLocationId { get; set; }
        //public string performingLocationName { get; set; }
        public string orderId { get; set; }
    }

    public class Item
    {
        public string code { get; set; }
    }

    public class Reports
    {
        public string status { get; set; }
        public int id { get; set; }
        public string MobileNo { get; set; }
        //public string ReportPDFUrl { get; set; }
        //public int subject { get; set; }
        public List<Extension> extension { get; set; }
        public List<Item> item { get; set; }

        public List<DocCertificates> DocCertificate = new List<DocCertificates>();
        public List<RadiologyCertificates> RadiologyCertificate = new List<RadiologyCertificates>();
        public string Location { get; set; }
    }

    public class ReportsResponse
    {
        public int totalCount { get; set; }
        public List<Reports> list { get; set; }
    }

    public class DocCertificates
    {
        public string UploadedOn { get; set; }
        public string LabNo { get; set; }
        public string statustype { get; set; }
        [JsonIgnore]
        public string entrydate { get; set; }

    }
    public class RadiologyCertificates
    {
        public string UploadedOn { get; set; }
        public string LabNo { get; set; }
        [JsonIgnore]
        public string entrydate { get; set; }
    }
}
