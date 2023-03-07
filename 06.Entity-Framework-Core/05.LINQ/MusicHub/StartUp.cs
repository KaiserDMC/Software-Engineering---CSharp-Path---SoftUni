using System.Globalization;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            // Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        //02. Albums Info
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter)
                        .ToArray(),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var album in albums)
            {
                stringBuilder.AppendLine($"-AlbumName: {album.AlbumName}");
                stringBuilder.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                stringBuilder.AppendLine($"-ProducerName: {album.ProducerName}");
                stringBuilder.AppendLine($"-Songs:");



                if (album.AlbumSongs.Length != 0)
                {
                    int songCounter = 1;

                    foreach (var song in album.AlbumSongs)
                    {

                        stringBuilder.AppendLine($"---#{songCounter}");
                        stringBuilder.AppendLine($"---SongName: {song.SongName}");
                        stringBuilder.AppendLine($"---Price: {song.SongPrice:f2}");
                        stringBuilder.AppendLine($"---Writer: {song.SongWriter}");

                        songCounter++;
                    }

                    songCounter = 1;
                }

                stringBuilder.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //03. Songs Above Duration
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongPerformer = s.SongPerformers
                        .Select(p => new
                        {
                            FullName = $"{p.Performer.FirstName} {p.Performer.LastName}"
                        })
                        .OrderBy(n => n.FullName.ToString())
                        .ToArray(),
                    SongWriter = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriter)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            int counter = 1;
            foreach (var song in songs)
            {
                stringBuilder.AppendLine($"-Song #{counter}");
                stringBuilder.AppendLine($"---SongName: {song.SongName}");
                stringBuilder.AppendLine($"---Writer: {song.SongWriter}");

                if (song.SongPerformer.Length != 0)
                {
                    foreach (var performer in song.SongPerformer)
                    {
                        stringBuilder.AppendLine($"---Performer: {performer.FullName}");
                    }
                }

                stringBuilder.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                stringBuilder.AppendLine($"---Duration: {song.SongDuration}");

                counter++;
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}

