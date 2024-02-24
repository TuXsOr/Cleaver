using System.Security.Cryptography;


namespace Cleaver.Classes
{
    internal class Splitter
    {
        AppInstance instance;
        Aes encryptor;
        SHA256 sha256;

        
        public Splitter(AppInstance inInstance)
        {
            instance = inInstance;
            encryptor = Aes.Create();
            encryptor.KeySize = 256;
            encryptor.Mode = CipherMode.CBC;

            sha256 = SHA256.Create();
        }

        public byte[] GetHash(byte[] inBytes) { return sha256.ComputeHash(inBytes, 0, inBytes.Length); }


        public byte[] EncryptBytes(byte[] inBytes, byte[] key, byte[] iv)
        {
            byte[] outBuffer = new byte[32];
            ICryptoTransform enc = encryptor.CreateEncryptor(key, iv);
            enc.TransformFinalBlock(inBytes, 0, inBytes.Length);

            return outBuffer;
        }


        public List<byte[]> SplitBytes(byte[] inBytes, int ChunkSize)
        {
            int index = 0;
            List<byte[]> chunks = new List<byte[]>();

            foreach (byte[] chunk in inBytes.Chunk(ChunkSize))
            {
                chunks.Add(chunk);
                index++;
            }

            return chunks;
        }
    }
}
