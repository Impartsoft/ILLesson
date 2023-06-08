using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    internal class ILPackVerification
    {
        public static void Save(MethodInfo method, Action<ILGenerator> actionIlGenerator)
        {
            var assembly = Assembly.GetAssembly(t);
            var generator = new Lokad.ILPack.AssemblyGenerator();

            // for ad-hoc serialization
            //var bytes = generator.GenerateAssemblyBytes(assembly);

            // direct serialization to disk
            generator.GenerateAssembly(assembly, "/path/to/file");
        }

        public static void Save(Type t)
        {
            var assembly = Assembly.GetAssembly(t);
            var generator = new Lokad.ILPack.AssemblyGenerator();

            // for ad-hoc serialization
            //var bytes = generator.GenerateAssemblyBytes(assembly);

            // direct serialization to disk
            generator.GenerateAssembly(assembly, "/path/to/file");
        }
    }
}
