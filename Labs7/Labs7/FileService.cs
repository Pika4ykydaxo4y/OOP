using HospitalRecordsModule.Models;

namespace HospitalRecordsModule.Services
{
    public class FileService
    {
        private const string OutputFileName = "TherapyReport.txt";

        public List<Patient> LoadPatients(string filePath)
        {
            var patients = new List<Patient>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length != 5) continue;

                var patient = new Patient
                {
                    LastName = parts[0],
                    BirthYear = int.Parse(parts[1]),
                    AdmissionDate = DateTime.Parse(parts[2]),
                    Diagnosis = Enum.Parse<DiagnosisType>(parts[3]),
                    DaysInHospital = int.Parse(parts[4])
                };
                patients.Add(patient);
            }
            return patients;
        }

        public void WriteReport(Dictionary<DiagnosisType, List<Patient>> groupedData)
        {
            using var writer = new StreamWriter(OutputFileName, false);

            writer.WriteLine("Терапевтическое отделение:");
            foreach (var group in groupedData)
            {
                writer.WriteLine();
                writer.WriteLine(group.Key + ":");

                var patients = group.Value;
                if (patients.Any())
                {
                    writer.WriteLine("№\tФамилия\tПродолжительность пребывания\tВозраст");
                    for (int i = 0; i < patients.Count; i++)
                    {
                        var p = patients[i];
                        writer.WriteLine($"{i + 1}\t{p.LastName}\t{p.DaysInHospital}\t{p.Age}");
                    }
                }
                else
                {
                    writer.WriteLine("больные не обнаружены.");
                }
            }
        }
    }
}
