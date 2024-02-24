
using System.Diagnostics;

namespace Cleaver.Classes
{
    internal static class FileManager
    {
        public static void WriteChunks(List<byte[]> chunkList)
        {
            int index = 0;
            foreach (byte[] chunk in  chunkList)
            {
                Debug.WriteLine($"Writing Chunk: {index}");
                File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\part{index}", chunk);
                index++;
            }
        }
    }
}
