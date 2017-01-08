using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erudit.Core;
using Erudit.Core.BO;

namespace Erudit.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new List<Letter>()
            {
                new Letter() {Value = 'м'},
                new Letter() {Value = 'б'},
                new Letter() {Value = 'и'},
                new Letter() {Value = 'е'},
                new Letter() {Value = 'д'},
                new Letter() {Value = 'й'},
                new Letter() {Value = 'г'},
                new Letter() {Value = 'в'},
            };

            var logic = new Logic(new List<Placeholder>(), arr);
            logic.GetWord();
        }
    }
}
