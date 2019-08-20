using System;
using System.Runtime.InteropServices;

namespace Wrapper
{
    
    public class Loader
    {
        [DllImport("pdfium.dll")] public static extern void FPDF_InitLibrary();

        [DllImport("pdfium.dll")] public static extern void FPDF_DestroyLibrary();

        [DllImport("pdfium.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FPDF_LoadDocument([MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.LPStr)] string password);

        [DllImport("pdfium.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FPDF_GetPageCount(IntPtr doc);

        public static void Test()
        {
            Console.WriteLine("Initializing PDFium Library...");

            FPDF_InitLibrary();

            string File = "C:/Users/edgar/source/repos/ConsoleApplication1/x64/Debug/file.pdf";

            Console.WriteLine("\nOpen PDF file in: " + File);

            IntPtr Doc = FPDF_LoadDocument(File, null);

            int pages = FPDF_GetPageCount(Doc);

            Console.WriteLine("\nNumber of Pages: " + pages);

            Console.WriteLine("\nDestroying library...");

            FPDF_DestroyLibrary();
            
        }

    }
}
