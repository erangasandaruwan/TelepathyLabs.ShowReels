using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelepathyLabs.ShowReels.Core
{
    public class ShowReelException : Exception
    {
        public ShowReelException() { }

        public ShowReelException(string message) : base(message) { }

        public ShowReelException(string message, Exception inner): base(message, inner) { }
    }
}
