// ReSharper disable ReturnValueOfPureMethodIsNotUsed

using System.IO;
using System.Linq;

using Elements.Common.Extensions;

using static System.Environment;
using static System.Environment.SpecialFolder;
using static System.IO.File;

using static Elements.Persistence.ContextConstructor;
using static Elements.Persistence.DatabasePathHelper;

namespace Elements.Persistence
{
    internal class DatabaseSetup
    {
        public void Setup()
        {
            Copy();
            WarmUp();
        }
        
        private void Copy()
        {
            Exists(DatabasePath())
                .IfFalse(() =>
                {
                    var assembly = GetType().Assembly;
                    var name = $"{assembly.Name()}.Database.{DatabaseName}";
                    using var stream = assembly.GetStream(name);
                    using var fileStream = OpenWrite(DatabasePath());
                    stream?.CopyTo(fileStream);
                });
        }

        private static void WarmUp()
            => Context()
                .Articles
                .First();
    }

    public static class DatabaseSetupRunner
    {
        public static void DatabaseSetup()
            => new DatabaseSetup()
                .Pipe(d => d.Setup());
    }

    internal static class DatabasePathHelper
    {
        public static string DatabasePath()
            => LocalApplicationData
                .Pipe(GetFolderPath)
                .Pipe(Join);

        private static string Join(string path)
            => Path.Join(path, DatabaseName);

        public static string DatabaseName
            = "Elements.db";
    }
}