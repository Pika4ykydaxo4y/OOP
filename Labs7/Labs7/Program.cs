using HospitalRecordsModule.Menu;
using HospitalRecordsModule.Services;

class Program
{
    // Имя входного файла с данными пациентов
    private const string InputFile = "patients.txt";

    /// <summary>
    /// Главная точка входа в приложение.
    /// </summary>
    static void Main()
    {
        // Создаём сервис для работы с файлами
        var fileService = new FileService();

        // Загружаем пациентов из файла
        var patients = fileService.LoadPatients(InputFile);

        // Запускаем меню
        var menu = new MenuHandler(patients);
        menu.ShowMenu();
    }
}
