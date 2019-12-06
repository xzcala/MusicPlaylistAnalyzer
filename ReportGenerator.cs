using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicPlaylistAnalyzer
{
    public static class ReportGenerator
    {
        public static void WriteReport(string filePath, List<Music> Playlist)
        {
            try
            {
                if (Playlist.Any() && Playlist != null)
                {
                    // Header
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Music Playlist Report");
                    builder.Append(Environment.NewLine);
                    builder.Append(Environment.NewLine);

                    //Question 1
                    builder.Append("Songs that received 200 or more plays: \n");

                    var highPlays = from currentSong in Playlist where currentSong.Plays >= 200 select currentSong;
                    foreach (Music currentSong in highPlays)
                    {
                        builder.Append(currentSong);
                        builder.Append(Environment.NewLine);
                    }
                    
                    builder.Append(Environment.NewLine);

                    //Question 2
                    builder.Append(string.Format("Number of Alternative songs: {0}", (from currentSong in Playlist where currentSong.Genre == "Alternative" select currentSong).Count()));

                    builder.Append(Environment.NewLine);
                    builder.Append(Environment.NewLine);

                    //Question 3
                    builder.Append(string.Format("Number of Hip-Hop/Rap songs: {0}", (from currentSong in Playlist where currentSong.Genre == "Hip-Hop/Rap" select currentSong).Count()));

                    builder.Append(Environment.NewLine);
                    builder.Append(Environment.NewLine);

                    //Question 4
                    builder.Append("Songs from the album Welcome to the Fishbowl: \n");

                    var fishbowlSongs = from currentSong in Playlist where currentSong.Album == "Welcome to the Fishbowl" select currentSong;
                    foreach (Music currentSong in fishbowlSongs)
                    {
                        builder.Append(currentSong);
                        builder.Append(Environment.NewLine);
                    }
                    
                    builder.Append(Environment.NewLine);

                    //Question 5
                    builder.Append("Songs from before 1970: \n");

                    var songsBefore1970 = from currentSong in Playlist where currentSong.Year < 1970 select currentSong;
                    foreach (Music currentSong in songsBefore1970)
                    {
                        builder.Append(currentSong);
                        builder.Append(Environment.NewLine);
                    }

                    builder.Append(Environment.NewLine);

                    //Question 6
                    builder.Append("Song names longer than 85 characters: \n");

                    var nameLongerThan85 = from currentSong in Playlist where currentSong.Name.Length > 85 select currentSong;
                    foreach (Music currentSong in nameLongerThan85)
                    {
                        builder.Append(currentSong);
                        builder.Append(Environment.NewLine);
                    }
                    
                    builder.Append(Environment.NewLine);

                    //Question 7
                    var longestSong = from currentSong in Playlist orderby currentSong.Time descending select currentSong;
                    builder.Append("Longest song: "+longestSong.First());

                    //Write finished report
                    using (var stream = new StreamWriter(filePath))
                    {
                        stream.Write(builder.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Test.");
                    Console.ReadLine();
                    Console.WriteLine("File is empty.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw e;
            }
        }
    }
}
