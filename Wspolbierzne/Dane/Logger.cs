using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.IO;
using static Dane.AbstractDataApi;

namespace Dane
{
    internal class Logger
    {
        private static List<Kulka> kulki;
        private Stopwatch stopWatch = new Stopwatch();

        public Logger(List<Kulka> k)
        {
            kulki = k;
            Thread t = new Thread(() =>
            {
                ClearLogFile();
                stopWatch.Start();
                while (true)
                {
                    if (stopWatch.ElapsedMilliseconds >= 1000)
                    {
                        stopWatch.Restart();
                        using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\niepo\\source\\repos\\repo\\Etap2\\Wspolbierzne\\Dane\\plik.txt", true))
                        {
                            string stamp = ($"Kulka in data: {DateTime.Now:R}");
                            foreach (Kulka kulka in kulki)
                            {
                                streamWriter.WriteLine(stamp + JsonSerializer.Serialize(kulki));
                            }

                        }
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        private void ClearLogFile()
        {
            try
            {
                File.WriteAllText("C:\\Users\\niepo\\source\\repos\\repo\\Etap2\\Wspolbierzne\\Dane\\plik.txt", string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while clearing the log file: " + ex.Message);
            }
        }

        public void stop()
        {
            stopWatch.Reset();
            stopWatch.Stop();
        }
    }
}
