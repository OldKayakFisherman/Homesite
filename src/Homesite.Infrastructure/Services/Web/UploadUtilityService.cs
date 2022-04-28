using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Web;
using Microsoft.AspNetCore.Http;

namespace Homesite.Infrastructure.Services.Web
{
    public class UploadUtilityService: IUploadUtilityService
    {
        public MemoryStream? ConvertPostedFileToMemoryStream(IFormFile formFile)
        {

            if (formFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    return ms;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
