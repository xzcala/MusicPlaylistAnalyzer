using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class FileReader
    {
        public static bool ReadFile(string filePath, List<Music> Playlist)
            {
            try
            {
                int length = 0;
                var lines = File.ReadAllLines(filePath);
                for (int index = 0; index < lines.Length; index++)
                {
                    var line = lines[index];
                    var data = line.Split('\t');

                    if (index == 0)
                    {
                        length = data.Length;
                    }
                    else
                    {
                        if (length != data.Length)
                        {
                            //return false;
                            throw new Exception(string.Format("Row {0} contains {1} values. It should contain 8.", index, data.Length));
                        }
                        else
                        {
                            try
                            {
                                Music values = new Music();
                                values.Name = data[0].ToString();
                                values.Artist = data[1].ToString();
                                values.Album = data[2].ToString();
                                values.Genre = data[3].ToString();
                                values.Size = Convert.ToInt32(data[4]);
                                values.Time = Convert.ToInt32(data[5]);
                                values.Year = Convert.ToInt32(data[6]);
                                values.Plays = Convert.ToInt32(data[7]);
                                Playlist.Add(values);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error reading data from txt file. Error: {0}", e.Message);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading data from txt file. Error: {0}", e.Message);
                throw e;
            }
        }
    }
    
}

