namespace ILLesson
{
    internal class Reference
    {

        /*
         	// Method begins at RVA 0x23ee
	        // Header size: 1
	        // Code size: 13 (0xd)
	        .maxstack 8

	        // {
	        IL_0000: nop
	        // Console.WriteLine("HelloWorld");
	        IL_0001: ldstr "HelloWorld"
	        IL_0006: call void [System.Console]System.Console::WriteLine(string)
	        // }
	        IL_000b: nop
	        IL_000c: ret
         */
        public void SayHelloWorld()
        {
            Console.WriteLine("HelloWorld");
        }

		/*
         	// Method begins at RVA 0x23fc
			// Header size: 12
			// Code size: 22 (0x16)
			.maxstack 3
			.locals init (
				[0] string
			)

			// {
			IL_0000: nop
			// return value.Replace("\"", "\\\"");
			IL_0001: ldarg.1
			IL_0002: ldstr "\""
			IL_0007: ldstr "\\\""
			IL_000c: callvirt instance string [System.Runtime]System.String::Replace(string, string)
			IL_0011: stloc.0
			// (no C# code)
			IL_0012: br.s IL_0014

			IL_0014: ldloc.0
			IL_0015: ret
         */
		public string Replace(string value)
        {
            return value.Replace("\"", "\\\"");
        }
    }
}
