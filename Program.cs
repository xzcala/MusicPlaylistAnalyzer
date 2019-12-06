using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static List<Music> Playlist = new List<Music>();

        static void Main(string[] args)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var playlistPath = string.Empty;
            var reportPath = string.Empty;

            if (args.Length != 2)
            {
                Console.WriteLine("Please enter valid syntax : MusicPlaylistAnalyzer.exe <music_playlist_file_path> <report_file_path>");
                Console.ReadLine();
                return;
            }
            else
            {
                playlistPath = args[0];
                reportPath = args[1];

                if (!playlistPath.Contains("\\"))
                {
                    playlistPath = Path.Combine(currentPath, playlistPath);
                }
                if (!reportPath.Contains("\\"))
                {
                    reportPath = Path.Combine(currentPath, reportPath);
                }
            }

            if (File.Exists(playlistPath))
            {
                if (FileReader.ReadFile(playlistPath, Playlist))
                {
                    try
                    {
                        var report = File.Create(reportPath);
                        report.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unable to create file. Error: " + e.Message);
                    }
                    ReportGenerator.WriteReport(reportPath, Playlist);
                }
                Console.WriteLine("Successfully created report. Press the Enter button to exit.");
            }
            else
            {
                Console.WriteLine("Playlist data file not found.");
            }
            
            Console.ReadLine();       
        }
    }
}
