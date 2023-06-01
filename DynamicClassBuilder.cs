using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ILLesson
{
    /*
     * CoreCLR不支持AssemblyBuilderAccess.RunAndSave与AssemblyBuilderAccess.Save
        https://github.com/dotnet/runtime/issues/15704
     * 
     */
    internal class DynamicClassBuilder
    {
        // Get the current application domain for the current thread
        AppDomain currentDomain = AppDomain.CurrentDomain;

        // Create a dynamic assembly in the current application domain,
        // and allow it to be executed and saved to disk.
        AssemblyName name = new AssemblyName("MyEnums");
        AssemblyBuilder assemblyBuilder = currentDomain.DefineDynamicAssembly(name,
                                              AssemblyBuilderAccess.RunAndSave);

        // Define a dynamic module in "MyEnums" assembly.
        // For a single-module assembly, the module has the same name as the assembly.
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(name.Name,
                                          name.Name + ".dll");

        // Define a public enumeration with the name "MyEnum" and an underlying type of Integer.
        EnumBuilder myEnum = moduleBuilder.DefineEnum("EnumeratedTypes.MyEnum",
                                 TypeAttributes.Public, typeof(int));

        var a = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Name"), AssemblyBuilderAccess.Save);
    }
}
