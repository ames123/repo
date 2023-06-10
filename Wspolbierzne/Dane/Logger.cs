using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;


namespace Dane
{
    internal class Logger
    {
        private static List<Kulka> kulki;
        //tworzy timer
        private Timer timer;

        public Logger(List<Kulka> k)
        {
            ClearLogFile();
            kulki = k;
            SetTimer();

        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\niepo\\source\\repos\\repo\\Etap2\\Wspolbierzne\\Dane\\plik.txt", true))
            {
                string stamp = ($"Kulka in data: {DateTime.Now:R}");
                foreach (Kulka kulka in kulki)
                {
                    //zapis do pliku
                    streamWriter.WriteLine(stamp + JsonSerializer.Serialize(kulki));
                }

            }
        }
        private void SetTimer()
        {
            //ustawiamy wywoływanie co 1 sekunde
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            //restart i automatyczne wznowienie timera
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void ClearLogFile()
        {
            try
            {
                //czyszczenie pliku
                File.WriteAllText("C:\\Users\\niepo\\source\\repos\\repo\\Etap2\\Wspolbierzne\\Dane\\plik.txt", string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while clearing the log file: " + ex.Message);
            }
        }
        //zatrzymuje timer
        public void stop()
        {
            timer.Stop();
        }
    }
}
