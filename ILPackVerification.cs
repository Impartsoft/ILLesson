using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    public class ILPackVerification
    {
        public static ModuleBuilder Builder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ILTest.Dynamic"), AssemblyBuilderAccess.Run).DefineDynamicModule("TestDynamicModule");
        public static void Save(DynamicMethod method, Action<ILGenerator> setIL)
        {
            var type = Builder.DefineType("ILPackVerificationClass", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed);
            var newMethod = type.DefineMethod(method.Name, method.Attributes, method.ReturnType, method.GetParameters().Select(v => v.ParameterType).ToArray());
            setIL(newMethod.GetILGenerator());
            Console.WriteLine("方法：" + method.Name + "开始保存...");

            Save(type.CreateType());
        }

        public static void Save(Type type)
        {
            var assembly = Assembly.GetAssembly(type);
            Console.WriteLine("类：" + type.Name + "开始保存...");

            Save(assembly);
        }

        public static void Save(Assembly dynamicAssembly)
        {
            var generator = new Lokad.ILPack.AssemblyGenerator();

            generator.GenerateAssembly(dynamicAssembly, "/dils.dll");
            Console.WriteLine("DLL输出成功！");
        }
    }
}
