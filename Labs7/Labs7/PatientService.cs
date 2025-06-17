using HospitalRecordsModule.Models;

namespace HospitalRecordsModule.Services
{
    public class PatientService
    {
        public List<Patient> FilterByDiagnosis(List<Patient> patients, DiagnosisType diagnosis)
        {
            return patients
                .Where(p => p.Diagnosis == diagnosis)
                .OrderByDescending(p => p.DaysInHospital)
                .ToList();
        }
    }
}
