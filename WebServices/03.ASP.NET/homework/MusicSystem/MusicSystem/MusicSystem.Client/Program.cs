using MusicSystem.Data;
using MusicSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSystem.Client
{
    class Program
    {
        static void Main()
        {
            //
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicDbContext, Configuration>());
            var db = new MusicDbContext();
            string title = "DevilsDance";
            using (db)
            {
                var song = db.Songs
                .FirstOrDefault(s => s.Title == title);
                Console.WriteLine(song.Title);
            }
            //db.Database.CreateIfNotExists();
        }
    }
}
