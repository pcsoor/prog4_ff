using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IStorageRepository
    {
        int Highscore { get; set; }
        int[,] Board { get; set; }
    }
}
