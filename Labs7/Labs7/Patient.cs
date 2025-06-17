namespace HospitalRecordsModule.Models
{
    public class Patient
    {
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DiagnosisType Diagnosis { get; set; }
        public int DaysInHospital { get; set; }

        public int Age => DateTime.Now.Year - BirthYear;
    }
}
