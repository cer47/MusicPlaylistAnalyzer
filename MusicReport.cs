using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace MusicPlaylistAnalyzer {
    public class MusicPlaylist {
        private List<Song> songs;
        public MusicPlaylist() {
            songs = new List<Song>();
        }
        public MusicPlaylist(List<Song> songs) {
            this.songs = songs;
        }
        public void GenerateReport(string filePath) {
            if (songs.Count == 0) {
                throw new Exception("Could not make Report: No songs in list. Please try again");
            }
            StreamWriter sw = null;
            try {
                sw = new StreamWriter(filePath);
                sw.WriteLine("* Music Playlist Report *\n");

                sw.WriteLine("Songs that received 200 of more plays:");
                IEnumerable<Song> maxPlayedSongs = from song in songs where song.Plays >= 200 select song;
                foreach (Song song in maxPlayedSongs) {
                    sw.WriteLine(song);
                }
                sw.WriteLine();
                sw.WriteLine(string.Format("Number of Alternative Songs: {0}\n", (from song in songs where song.Genre == "Alternative" select song).Count()));
                sw.WriteLine(string.Format("Number of Hip-Hop/Rap Songs: {0}\n", (from song in songs where song.Genre == "Hip-Hop/Rap" select song).Count()));
                sw.WriteLine("Songs from the album \"Welcome to the Fishbowl\":");
                IEnumerable<Song> FishAlbumSongs = from song in songs where song.Album == "Welcome to the Fishbowl" select song;
                foreach (Song song in FishAlbumSongs) {
                    sw.WriteLine(song);
                }
                sw.WriteLine();
                sw.WriteLine("Songs from before 1970:");
                IEnumerable<Song> OldSongs = from song in songs where song.Year < 1970 select song;
                foreach (Song song in OldSongs) {
                    sw.WriteLine(song);
                }
                sw.WriteLine();
                sw.WriteLine("Songs names longer than 85 characters:");
                IEnumerable<Song> longSongNames = from song in songs where song.Name.Length > 85 select song;
                foreach (Song song in longSongNames) {
                    sw.WriteLine(song);
                }
                sw.WriteLine();
                sw.WriteLine(string.Format("Longest song: {0}", (from song in songs orderby song.Time descending select song).FirstOrDefault()));
            } catch (Exception error) {
                throw error;
            } finally {
                if (sw != null) {
                    sw.Close();
                }
            }
        }
    }
}
				
				