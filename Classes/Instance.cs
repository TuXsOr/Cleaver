
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

                byte[] encryptedFile = splitter.EncryptBytes(fileBytes, key, iv);


                List<byte[]> chunks = splitter.SplitBytes(encryptedFile, chunkSize);
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


        public bool ReconstructFile(List<string> partPaths, string password)
        {
            rebuildMenu.UpdateDisplayMessage("Loading Parts...", Color.CadetBlue);

            List<byte[]> readFiles = new List<byte[]>();

            foreach (string partPath in partPaths)
            {
                if (!File.Exists(partPath)) { continue; }

                readFiles.Add(File.ReadAllBytes(partPath));
            }

            List<byte[]>? decryptedChunks = splitter.DecryptChunks(readFiles, splitter.GetHash(Encoding.UTF8.GetBytes(password)), new byte[16]);
            if (decryptedChunks == null) { return false; }

            bool isSorted = false;
            List<byte[]> sortedChunks = new List<byte[]>();
            int curPart = 0;

            while (!isSorted)
            {
                foreach (byte[] chunk in decryptedChunks)
                {
                    string chunkString = Encoding.UTF8.GetString(chunk);
                    string[] parsedChunk = chunkString.Split(new string[] { "!&!" }, StringSplitOptions.None);

                    if (int.Parse(parsedChunk[1]) == curPart) { sortedChunks.Add(Encoding.UTF8.GetBytes(parsedChunk[0])); curPart++; Debug.WriteLine($"Added Chunk: {parsedChunk[1]}"); }
                }
                if (sortedChunks.Count >= decryptedChunks.Count) { isSorted = true; }
            }
            rebuildMenu.UpdateDisplayMessage("Re-assembling File..", Color.CadetBlue);

            List<byte> combinedBytes = new List<byte>();

            foreach (byte[] chunk in decryptedChunks)
            {
                foreach (byte b in chunk)
                {
                    combinedBytes.Add(b);
                }
            }

            byte[] combinedFile = combinedBytes.ToArray();
            File.WriteAllBytes("C:\\users\\someone\\desktop\\outFile", combinedFile);
            // byte[] originalFile =  splitter.DecryptBytes(combinedFile, splitter.GetHash(Encoding.UTF8.GetBytes(password)), new byte[16]);
            // File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\reconstructed_file", originalFile);

            return true;
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
