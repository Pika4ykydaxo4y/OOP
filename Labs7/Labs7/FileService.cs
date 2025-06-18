using HospitalRecordsModule.Models;

namespace HospitalRecordsModule.Services
{
    /// <summary>
    /// Сервис для загрузки и сохранения данных пациентов.
    /// </summary>
    public class FileService
    {
        private const char Separator = ';';

        /// <summary>
        /// Загружает пациентов из текстового файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Список пациентов</returns>
        public List<Patient> LoadPatients(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var patients = new List<Patient>();

            foreach (var line in lines)
            {
                var parts = line.Split(Separator);

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

        /// <summary>
        /// Сохраняет отчёт по группам диагнозов в текстовый файл.
        /// </summary>
        /// <param name="groupedPatients">Группировка пациентов по диагнозу</param>
        public void WriteReport(Dictionary<DiagnosisType, IEnumerable<Patient>> groupedPatients)
        {
            const string OutputFile = "report.txt";

            // Создание нового файла (если существует — перезаписывается)
            using var writer = new StreamWriter(OutputFile, append: false);

            foreach (var (diagnosis, patients) in groupedPatients)
            {
                // Заголовок отделения (на английском)
                string departmentTitle = diagnosis switch
                {
                    DiagnosisType.Flu => "Therapeutic department:",
                    DiagnosisType.Angina => "Cardiology department:",
                    DiagnosisType.Pneumonia => "Pulmonology department:",
                    _ => "Unknown department:"
                };


                writer.WriteLine(departmentTitle);

                foreach (var patient in patients)
                {
                    writer.WriteLine($"{patient.LastName}, {patient.Age} years old, {patient.DaysInHospital} days");
                }

                writer.WriteLine(); // Пустая строка между отделениями
            }
        }

    }
}
