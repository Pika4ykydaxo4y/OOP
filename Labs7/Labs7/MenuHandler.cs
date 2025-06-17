using HospitalRecordsModule.Models;
using HospitalRecordsModule.Services;

namespace HospitalRecordsModule.Menu
{
    public class MenuHandler
    {
        private readonly List<Patient> _patients;
        private readonly PatientService _patientService;
        private readonly FileService _fileService;

        public MenuHandler(List<Patient> patients)
        {
            _patients = patients;
            _patientService = new PatientService();
            _fileService = new FileService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите диагноз:");
                var values = Enum.GetValues<DiagnosisType>();
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {values[i]}");
                }

                Console.WriteLine("0. Выход");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0) break;

                    if (choice > 0 && choice <= values.Length)
                    {
                        var selectedDiagnosis = values[choice - 1];
                        var filtered = _patientService.FilterByDiagnosis(_patients, selectedDiagnosis);

                        Console.Clear();
                        Console.WriteLine($"Пациенты с диагнозом: {selectedDiagnosis}");
                        foreach (var p in filtered)
                        {
                            Console.WriteLine($"{p.LastName}, {p.Age} лет, {p.DaysInHospital} дней");
                        }

                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
            }

            var grouped = Enum.GetValues<DiagnosisType>()
                .ToDictionary(
                    d => d,
                    d => _patientService.FilterByDiagnosis(_patients, d));

            _fileService.WriteReport(grouped);
        }
    }
}
