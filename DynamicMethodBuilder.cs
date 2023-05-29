using System.Reflection.Emit;

namespace ILLesson
{
    internal class DynamicMethodBuilder
    {
        public static void CreateHelloWorldMethod()
        {
            var method = new DynamicMethod("SayHelloWorld", typeof(void), null);
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldstr, "HelloWorld");
            il.Emit(OpCodes.Call, typeof(Console).GetMethod(nameof(Console.WriteLine), new Type[1] { typeof(string) }));

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ret);

            var methodDelegate = (Action)method.CreateDelegate(typeof(Action));
            methodDelegate();
        }
    }
}
