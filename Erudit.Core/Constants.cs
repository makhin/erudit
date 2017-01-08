using System.IO;
using System.Reflection;
using Erudit.Core.BO;

namespace Erudit.Core
{
    public static class Constants
    {
        public static Letter[] Alphabet =
        {
            new Letter {Value = 'а', Score = 1},
            new Letter {Value = 'б', Score = 3},
            new Letter {Value = 'в', Score = 1},
            new Letter {Value = 'г', Score = 3},
            new Letter {Value = 'д', Score = 2},
            new Letter {Value = 'е', Score = 1},
            new Letter {Value = 'ж', Score = 5},
            new Letter {Value = 'з', Score = 5},
            new Letter {Value = 'и', Score = 1},
            new Letter {Value = 'й', Score = 4},
            new Letter {Value = 'к', Score = 2},
            new Letter {Value = 'л', Score = 2},
            new Letter {Value = 'м', Score = 2},
            new Letter {Value = 'н', Score = 1},
            new Letter {Value = 'о', Score = 1},
            new Letter {Value = 'п', Score = 2},
            new Letter {Value = 'р', Score = 1},
            new Letter {Value = 'с', Score = 1},
            new Letter {Value = 'т', Score = 1},
            new Letter {Value = 'у', Score = 2},
            new Letter {Value = 'ф', Score = 8},
            new Letter {Value = 'х', Score = 5},
            new Letter {Value = 'ц', Score = 5},
            new Letter {Value = 'ч', Score = 5},
            new Letter {Value = 'ш', Score = 8},
            new Letter {Value = 'щ', Score = 10},
            new Letter {Value = 'ъ', Score = 15},
            new Letter {Value = 'ы', Score = 4},
            new Letter {Value = 'ь', Score = 3},
            new Letter {Value = 'э', Score = 8},
            new Letter {Value = 'ю', Score = 8},
            new Letter {Value = 'я', Score = 3},
            new Letter {Value = '.', Score = 0}
        };

        public static string Words { get; private set; }

        static Constants()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Erudit.Core.words.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                Words = reader.ReadToEnd();
            }
        }
    }
}