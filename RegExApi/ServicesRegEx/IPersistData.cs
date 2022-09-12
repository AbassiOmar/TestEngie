using RegExModels.Models.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesRegEx
{
    public interface IPersistData
    {
        void SetData(ResponseMatching responseMatching);

        List<ResponseMatching> GetData();
    }
}
