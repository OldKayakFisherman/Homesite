using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestUtilities;


namespace Homesite.Infrastructure.Tests.Services.Process
{ 
    public class ProjectImportServiceTests
    {
        [Test]
        public void TestImportProjects()
        {
            MemoryStream ms = FileTestUtilities.ReadAssetFileAsStream("ProjectImportTestAsset.xlsx", TestContext.CurrentContext);

            Assert.IsNotNull(ms);
        }
    }
}
