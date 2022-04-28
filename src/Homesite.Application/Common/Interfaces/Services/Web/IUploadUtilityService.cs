using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Homesite.Application.Common.Interfaces.Services.Web
{
    public interface IUploadUtilityService
    {
        MemoryStream? ConvertPostedFileToMemoryStream(IFormFile formFile);
    }
}
