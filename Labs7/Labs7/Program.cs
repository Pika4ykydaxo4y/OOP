using HospitalRecordsModule.Menu;
using HospitalRecordsModule.Services;

class Program
{
    private const string InputFile = "patients.txt";

    static void Main()
    {
        var fileService = new FileService();
        var patients = fileService.LoadPatients(InputFile);

        var menu = new MenuHandler(patients);
        menu.ShowMenu();
    }
}
