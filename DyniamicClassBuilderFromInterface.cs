using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    internal class DyniamicClassBuilderFromInterface
    {
        public interface IHelloWrold
        {
            public void SayHelloWorld();
        }

        public class CreateDynamicHelloWorldInterfaceClass
        {
            public static void CreateHelloWorldClass()
            {
                var parentType = typeof(IHelloWrold);

                var newClass = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ILTest.Dynamic"), AssemblyBuilderAccess.Run).DefineDynamicModule("TestDynamicModule").DefineType("ILPackVerificationClass", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed);

                newClass.AddInterfaceImplementation(typeof(IHelloWrold));
                var newMethod = newClass.DefineMethod(nameof(IHelloWrold.SayHelloWorld), MethodAttributes.Public | MethodAttributes.Virtual, typeof(void), Type.EmptyTypes);
                CreateHelloWorldIL(newMethod.GetILGenerator());
                var newInstance = (IHelloWrold)Activator.CreateInstance(newClass.CreateType()) ?? new object();
                newInstance.SayHelloWorld();
            }

            private static void CreateHelloWorldIL(ILGenerator il)
            {
                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldstr, "HelloWorld");
                il.Emit(OpCodes.Call, typeof(Console).GetMethod(nameof(Console.WriteLine), new Type[1] { typeof(string) }));
                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ret);
            }
        }
    }
}