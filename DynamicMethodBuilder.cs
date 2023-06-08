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

        public static void CreateEscapeQuotesMethod()
        {
            var method = new DynamicMethod("EscapeQuotes", typeof(string), new Type[1] { typeof(string) });
            IL_EscapeQuotes(method.GetILGenerator());
            ILPackVerification.Save(method, IL_EscapeQuotes);
            var methodDelegate = method.CreateDelegate<Func<string, string>>();
            string result = (string)methodDelegate.DynamicInvoke("dafdasf");
            Console.WriteLine(result);
            static void IL_EscapeQuotes(ILGenerator il)
            {
                il.DeclareLocal(typeof(string));
                var lb = il.DefineLabel();
                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldarg_0);//将第一个参数放置到堆栈上
                il.Emit(OpCodes.Ldstr, "\"");
                il.Emit(OpCodes.Ldstr, "\\\"");
                il.Emit(OpCodes.Call, typeof(string).GetMethod(nameof(string.Replace), new Type[2] { typeof(string), typeof(string) }));
                il.Emit(OpCodes.Stloc_0);//将栈顶元素存储到本地变量0中
                il.Emit(OpCodes.Br_S, lb);
                il.MarkLabel(lb);
                il.Emit(OpCodes.Ldloc_0);// 将本地变量表中索引为0的变量加载到堆栈中
                il.Emit(OpCodes.Ret);
            }
        }
    }
}
