using System;
using System.Collections.Generic;
using System.Text;

namespace PC_Shop_classLibrary.Service.Interface
{
    public interface IBankaService
    {
        List<Models.BankaVM> GetBanka();
        Models.Request.BankaModelRequest insertBanka(Models.Request.BankaModelRequest request);
    }
}
