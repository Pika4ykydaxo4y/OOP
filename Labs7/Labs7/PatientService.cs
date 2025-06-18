using HospitalRecordsModule.Models;

namespace HospitalRecordsModule.Services
{
    /// <summary>
    /// Сервис для работы с логикой, связанной с пациентами.
    /// </summary>
    public class PatientService
    {
        /// <summary>
        /// Фильтрует пациентов по заданному диагнозу.
        /// </summary>
        /// <param name="patients">Исходный список пациентов</param>
        /// <param name="diagnosis">Диагноз для фильтрации</param>
        /// <returns>Список пациентов с заданным диагнозом</returns>
        public IEnumerable<Patient> FilterByDiagnosis(IEnumerable<Patient> patients, DiagnosisType diagnosis)
        {
            return patients.Where(p => p.Diagnosis == diagnosis);
        }

        /// <summary>
        /// Преобразует данные пациента в строку определенного формата.
        /// </summary>
        /// <param name="patient">Пациент</param>
        /// <param name="formatOption">Выбранный формат</param>
        /// <returns>Отформатированная строка для отображения</returns>
        public string FormatPatient(Patient patient, OutputFormat formatOption)
        {
            return formatOption switch
            {
                OutputFormat.NameAndAge =>
                    $"{patient.LastName}, {patient.Age} years old",

                OutputFormat.NameDateAndBirthYear =>
                    $"{patient.LastName}, admitted: {patient.AdmissionDate:dd.MM.yyyy}, born: {patient.BirthYear}",

                _ => throw new ArgumentOutOfRangeException(nameof(formatOption), "Unsupported output format")
            };
        }
    }

    /// <summary>
    /// Опции форматов вывода информации о пациенте.
    /// </summary>
    public enum OutputFormat
    {
        // Фамилия и возраст
        NameAndAge,

        // Фамилия, дата поступления и год рождения
        NameDateAndBirthYear
    }
}
