﻿using System.Reflection;
using System.Reflection.Emit;

namespace ILLesson
{
    internal class DyniamicClassBuilderFromAbstractClass
    {
        public abstract class HelloWrold
        {
            public abstract void SayHelloWorld();
        }

        public static void CreateHelloWorldClass()
        {
            var parentType = typeof(HelloWrold);

            var newClass = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ILTest.Dynamic"), AssemblyBuilderAccess.Run).DefineDynamicModule("TestDynamicModule").DefineType("ILPackVerificationClass", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed, parentType);

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