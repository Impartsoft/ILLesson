using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    public abstract class HelloWrold
    {
        public abstract void SayHelloWorld();
    }

    internal class DyniamicClassBuilderFromAbstractClass
    {
        public static void CreateHelloWorldClass()
        {
            var parentType = typeof(HelloWrold);
            var newClass = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ILTest.Dynamic"), AssemblyBuilderAccess.Run).DefineDynamicModule("TestDynamicModule").DefineType("SubILTest"
                    , TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed, parentType);

            var oldMethod = parentType.GetMethod(nameof(HelloWrold.SayHelloWorld));
            var newMethod = newClass.DefineMethod(oldMethod.Name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, oldMethod.ReturnType
                    , oldMethod.GetParameters().Select(v => v.ParameterType).ToArray());

            CreateHelloWorldIL(newMethod.GetILGenerator());
            newClass.DefineMethodOverride(newMethod, oldMethod);
            var newInstance = (HelloWrold)Activator.CreateInstance(newClass.CreateType());
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