using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortunaPick
{
    internal interface IGameResults
    {
        public string? Game { get; }
        public DateOnly? Date { get; }
        public int? Ball1 { get; }
        public int? Ball2 { get; }
        public int? Ball3 { get; }
        public int? Ball4 { get; }
        public int? Ball5 { get; }
    }
}
