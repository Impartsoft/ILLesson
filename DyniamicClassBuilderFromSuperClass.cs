using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    internal class DyniamicClassBuilderFromSuperClass
    {
        public abstract class HelloWrold
        {
            public abstract void SayHelloWorld();
        }

        public static void CreateHelloWorldClass()
        {
            var parentType = typeof(HelloWrold);

           
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