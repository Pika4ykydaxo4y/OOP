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
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose diagnose:");
                var diagnosisValues = Enum.GetValues<DiagnosisType>();

                for (int i = 0; i < diagnosisValues.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {diagnosisValues[i]}");
                }

                Console.WriteLine("0. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        isRunning = false;
                        continue;
                    }

                    if (choice > 0 && choice <= diagnosisValues.Length)
                    {
                        var selectedDiagnosis = diagnosisValues[choice - 1];
                        var filteredPatients = _patientService.FilterByDiagnosis(_patients, selectedDiagnosis);

                        DisplayPatientsByFormat(filteredPatients, selectedDiagnosis);
                    }
                }
            }

            SaveReport();
        }

        private void DisplayPatientsByFormat(IEnumerable<Patient> patients, DiagnosisType diagnosis)
        {
            Console.Clear();
            Console.WriteLine($"Patients diagnosed with: {diagnosis}\n");

            Console.WriteLine("Press the key:");
            Console.WriteLine("Home - Last name, age");
            Console.WriteLine("End — Last name, date of admission, year of birth");

            var keyPressed = Console.ReadKey(true).Key;

            switch (keyPressed)
            {
                case ConsoleKey.Home:
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"{patient.LastName}, age: {patient.Age}");
                    }
                    break;

                case ConsoleKey.End:
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"{patient.LastName}, date of receipt: {patient.AdmissionDate:yyyy-MM-dd}, year of birth: {patient.BirthDate.Year}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid key. Press Home or End.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        private void SaveReport()
        {
            var groupedPatients = Enum
                .GetValues<DiagnosisType>()
                .ToDictionary(
                    diagnosis => diagnosis,
                    diagnosis => _patientService.FilterByDiagnosis(_patients, diagnosis)
                );

            _fileService.WriteReport(groupedPatients);
        }
    }
}
