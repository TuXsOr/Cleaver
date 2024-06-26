﻿using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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


        public byte[] DecryptBytes(byte[] inBytes, byte[] key, byte[] iv)
        {
            using (ICryptoTransform decryptor = encryptor.CreateDecryptor(key, iv))
            {
                return decryptor.TransformFinalBlock(inBytes, 0, inBytes.Length);
            }
        }


        public List<byte[]>? DecryptChunks(List<byte[]> inChunks, byte[] key, byte[] iv)
        {
            List<byte[]> decryptedParts = new List<byte[]>();
            try
            {
                using (ICryptoTransform decryptor = encryptor.CreateDecryptor(key, iv))
                {
                    foreach (byte[] partBytes in inChunks)
                    {
                        decryptedParts.Add(decryptor.TransformFinalBlock(partBytes, 0, partBytes.Length));
                    }
                }
            }
            catch { return null; }

            return decryptedParts;
        }


        public byte[] EncryptBytes(byte[] inBytes, byte[] key, byte[] iv)
        {
            using (ICryptoTransform enc = encryptor.CreateEncryptor(key, iv) )
            {
                byte[] result = enc.TransformFinalBlock(inBytes, 0, inBytes.Length);
                return result;
            }
        }


        public List<byte[]> SplitBytes(byte[] inBytes, int ChunkSize)
        {
            int index = 0;
            List<byte[]> chunks = new List<byte[]>();

            foreach (byte[] chunk in inBytes.Chunk(ChunkSize))
            {
                byte[] header = Encoding.UTF8.GetBytes($"!&!{index}");
                List<byte> buffer = new List<byte>();

                foreach (byte curByte in chunk)  // add bytes to list
                {
                    buffer.Add(curByte);
                }
                foreach (byte headerByte in header)  // add header to list
                {
                    buffer.Add(headerByte);
                }

                chunks.Add(buffer.ToArray());

                index++;
            }

            return chunks;
        }
    }
}
