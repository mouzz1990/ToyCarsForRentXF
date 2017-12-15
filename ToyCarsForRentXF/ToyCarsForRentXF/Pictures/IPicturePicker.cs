using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsForRentXF.Pictures
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
