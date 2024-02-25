
using System.Diagnostics;
using System.Text;

namespace Cleaver.Classes
{
    internal class AppInstance : ApplicationContext
    {
        internal Splitter splitter;
        internal SplitMenu menu;
        internal SelectMenu selectMenu;
        internal RebuildMenu rebuildMenu;

        public AppInstance()
        {
            splitter = new Splitter(this);
            menu = new SplitMenu(this);
            selectMenu = new SelectMenu(this);
            rebuildMenu = new RebuildMenu(this);
            selectMenu.Show();
        }

        internal bool SplitFile(string filePath, int chunkSize, byte[] key, byte[] iv)
        {
            try
            {
                menu.UpdateMessage("Reading File", Color.DarkCyan);

                byte[] fileBytes = File.ReadAllBytes(filePath);

                // byte[] encryptedFile = splitter.EncryptBytes(fileBytes, key, iv);


                List<byte[]> chunks = splitter.SplitBytes(fileBytes, chunkSize);
                int index = 0;

                List<byte[]> endList = new List<byte[]>();

                foreach (byte[] chunk in chunks)
                {
                    Debug.WriteLine($"Encrypting Chunk {index}");
                    menu.UpdateMessage($"Encrypting Chunk {index + 1}", Color.DarkCyan);

                    byte[] encBytes = splitter.EncryptBytes(chunk, key, iv);
                    endList.Add(encBytes);
                    index++;
                }

                FileManager.WriteChunks(endList, false);
                menu.UpdateMessage("Finished Splitting File!", Color.DarkGreen);
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error!!!!!!!!!!!!!!!! \\/\n{ex}");
                return false;
            }
        }


        public async Task ReconstructFile(List<string> partPaths, string password)
        {

            // Reading Part Files
            List<byte[]> readFiles = new List<byte[]>();
            foreach (string part in partPaths)
            {
                byte[] curFileBytes = await File.ReadAllBytesAsync(part);
                readFiles.Add(curFileBytes);
            }


            // Get entered password
            byte[] key = splitter.GetHash(Encoding.UTF8.GetBytes(password));


            // Decrypting parts
            List<byte[]> decryptedFiles = new List<byte[]>();
            foreach (byte[] file in readFiles)
            {
                byte[] decryptedFile = splitter.DecryptBytes(file, key, new byte[16]);
                decryptedFiles.Add(decryptedFile);
            }


            // Sort Decrypted parts
            List<byte[]> sortedParts = new List<byte[]>();
            bool sorted = false;
            int targetChunk = 0;
            while (!sorted)  // Sort Loop
            {
                Debug.WriteLine("Round of sorting");
                foreach (byte[] part in decryptedFiles)
                {
                    int headerIndex = -1;

                    for (int offset = part.Length - 4; offset > 0; offset--) // Search for header
                    {
                        string header = "!&!";
                        byte[] searchSegment = new byte[] { part[offset], part[offset + 1], part[offset + 2] };

                        if (Encoding.UTF8.GetString(searchSegment) == header)
                        {
                            Debug.WriteLine("Found Header");
                            headerIndex = offset;
                            break;
                        }
                    }
                    if (headerIndex == -1) { Debug.WriteLine("Failed to find header info"); }


                    // Parse index
                    Debug.WriteLine($"Parsing Index. Index Len: {(part.Length) - (headerIndex + 3)}");
                    byte[] indexBytes = new byte[(part.Length) - (headerIndex + 3)];
                    int tempIndex = 0;
                    for (int i = headerIndex + 3; i < part.Length; i++)
                    {
                        indexBytes[tempIndex] = part[i];
                        tempIndex++;
                    }
                    int partIndex = int.Parse(Encoding.UTF8.GetString(indexBytes));


                    if (partIndex == targetChunk) // if is the same index as the target chunk
                    {
                        // Remove Header from Chunk
                        Debug.WriteLine("Removing Header From Binary");
                        byte[] tmpBuffer = new byte[headerIndex + 1];
                        for (int i = 0; i < tmpBuffer.Length; i++)
                        {
                            tmpBuffer[i] = part[i];
                        }
                        targetChunk++;
                        sortedParts.Add(tmpBuffer);
                    }
                }
                if (sortedParts.Count == decryptedFiles.Count) { sorted = true; }
            }
            Debug.WriteLine("Sorted");


            // Recombine part binaries
            List<byte> combinedFile = new List<byte>();
            foreach (byte[] part in sortedParts)
            {
                foreach (byte b in part)
                {
                    combinedFile.Add(b);
                }
            }
            Debug.WriteLine("Combined File");

            // Decrypt Combined File
            //byte[] finalFile = splitter.DecryptBytes(combinedFile.ToArray(), key, new byte[16]);

            // Temporarily removed first layer of encryption

            File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\CombinedFile", combinedFile.ToArray());
            Debug.WriteLine("Wrote End File");
        }


        public void HideAllWindows()
        {
            selectMenu.Hide();
            menu.Hide();
            rebuildMenu.Hide();
            selectMenu = new SelectMenu(this);
            menu = new SplitMenu(this);
            rebuildMenu = new RebuildMenu(this);
        }


        public void SwitchMenu(string newMenu)
        {
            HideAllWindows();

            switch (newMenu.ToLower())
            {
                case "select":
                    if (selectMenu == null) { selectMenu = new SelectMenu(this); }
                    selectMenu.Show();
                    break;

                case "rebuild":
                    HideAllWindows();
                    rebuildMenu.Show();
                    break;

                case "split":
                    if (menu.Disposing || menu == null) { menu = new SplitMenu(this); }
                    menu.Show();
                    break;
            }
        }

        internal void Close() { ExitThread(); }
    }
}
