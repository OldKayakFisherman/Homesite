using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilities
{
    public static class FileTestUtilities
    {
        public static MemoryStream ReadAssetFileAsStream(string filename, TestContext ctx)
        {
            return new MemoryStream(File.ReadAllBytes(Path.Combine(ctx.WorkDirectory, "Assets", filename)));
        }
    }
}
