
using System.Diagnostics;

namespace Cleaver.Classes
{
    internal static class FileManager
    {
        public static void WriteChunks(List<byte[]> chunkList, bool test)
        {
            int index = 0;
            foreach (byte[] chunk in chunkList)
            {
                Debug.WriteLine($"Writing Chunk: {index}");

                if (test) { File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\decrypted-part{index}", chunk); }
                else { File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\part{index}", chunk); }
                index++;
            }
        }
    }
}
