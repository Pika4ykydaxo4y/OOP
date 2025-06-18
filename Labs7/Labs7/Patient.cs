namespace HospitalRecordsModule.Models
{
    /// <summary>
    /// Представляет данные о пациенте.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Фамилия пациента.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Год рождения пациента.
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Дата поступления пациента в больницу.
        /// </summary>
        public DateTime AdmissionDate { get; set; }

        /// <summary>
        /// Диагноз пациента.
        /// </summary>
        public DiagnosisType Diagnosis { get; set; }

        /// <summary>
        /// Количество дней, проведённых пациентом в больнице.
        /// </summary>
        public int DaysInHospital { get; set; }

        /// <summary>
        /// Возраст пациента (вычисляется автоматически).
        /// </summary>
        public int Age => DateTime.Now.Year - BirthYear;

        /// <summary>
        /// Полная дата рождения (предполагается 1 января года рождения).
        /// </summary>
        public DateTime BirthDate => new DateTime(BirthYear, 1, 1);
    }
}
