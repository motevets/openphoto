using System;
using OpenCvSharp;

public static class Program
{
    public static int Main(string[] args)
    {
        string outputPath;
        int cameraIndex;

        if (args.Length != 2 || string.IsNullOrEmpty(args[0])) {
            Console.WriteLine("Path missing, usage example:");
            Console.WriteLine("  openphoto.exe CAMERA_INDEX OUTPUT_FILE_PATH");
            Console.WriteLine("");
            Console.WriteLine("Example:");
            Console.WriteLine("  openphoto.exe 0 C:\\Users\\user\\foo.png");

            return 1;
        } else {
            cameraIndex = Int16.Parse(args[0]);
            outputPath = args[1];
        }

        try {
            var capture = new VideoCapture(cameraIndex);
            var image = new Mat();
            capture.Read(image);
            var bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            bitmap.Save(outputPath);
            return 0;
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
            return 1;
        }
    }
}
