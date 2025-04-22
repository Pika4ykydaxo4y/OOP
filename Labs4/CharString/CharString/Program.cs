using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = // дорабатываю;

        try
        {
            string[] sentences = input.Split('.', StringSplitOptions.RemoveEmptyEntries);
            List<string> validAddresses = new List<string>();
            DateTime now = DateTime.Now;
            DateTime today = now.Date;
            DateTime yesterday = today.AddDays(-1);
            TimeSpan thresholdTime = new TimeSpan(13, 0, 0);

            foreach (string sentence in sentences)
            {
                string trimmed = sentence.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                // Проверка наличия URL, даты и времени
                string urlPattern = @"(https?|ftp):\/\/[^\s]+";
                string datePattern = @"(\d{2}[./]\d{2}[./]\d{2,4})";
                string timePattern = @"(\d{2})-(\d{2})";

                Match urlMatch = Regex.Match(trimmed, urlPattern);
                Match dateMatch = Regex.Match(trimmed, datePattern);
                Match timeMatch = Regex.Match(trimmed, timePattern);

                if (!urlMatch.Success || !dateMatch.Success || !timeMatch.Success)
                    throw new Exception($"Неверный формат в предложении: \"{trimmed}\"");

                string url = urlMatch.Value;
                string dateStr = dateMatch.Value;
                string timeStr = timeMatch.Value;

                // Парсинг времени
                int hour = int.Parse(timeMatch.Groups[1].Value);
                int minute = int.Parse(timeMatch.Groups[2].Value);
                if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
                    throw new Exception($"Неверное время в предложении: \"{trimmed}\"");

                TimeSpan connectionTime = new TimeSpan(hour, minute, 0);

                // Парсинг даты
                DateTime connectionDate;
                string[] formats = { "dd.MM.yyyy", "dd/MM/yy", "dd.MM.yy" };
                if (!DateTime.TryParseExact(dateStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out connectionDate))
                    throw new Exception($"Неверная дата в предложении: \"{trimmed}\"");

                if ((connectionDate.Date == today || connectionDate.Date == yesterday) && connectionTime >= thresholdTime)
                {
                    validAddresses.Add(url);
                }
            }

            // Вывод результата
            Console.WriteLine("Адреса, подключение к которым было сегодня или вчера после 13:00:");
            foreach (var addr in validAddresses)
            {
                Console.WriteLine(addr);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
