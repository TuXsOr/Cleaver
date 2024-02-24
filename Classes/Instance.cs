
using System.Diagnostics;

namespace Cleaver.Classes
{
    internal class AppInstance : ApplicationContext
    {
        internal Splitter splitter;
        internal SplitMenu menu;
        internal SelectMenu selectMenu;

        public AppInstance()
        {
            splitter = new Splitter(this);
            menu = new SplitMenu(this);
            selectMenu = new SelectMenu(this);
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

                FileManager.WriteChunks(endList);
                menu.UpdateMessage("Finished Splitting File!", Color.DarkGreen);
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error!!!!!!!!!!!!!!!! \\/\n{ex}");
                return false;
            }
        }


        public void HideAllWindows()
        {
            selectMenu.Hide();
            menu.Hide();
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
                case "reconstruct":
                    // HideAllWindows();
                    // Insert menu here
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
