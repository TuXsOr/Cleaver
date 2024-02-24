
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
                byte[] fileBytes = File.ReadAllBytes(filePath);
                byte[] encryptedFile = splitter.EncryptBytes(fileBytes, key, iv);
                


                List<byte[]> chunks = splitter.SplitBytes(encryptedFile, chunkSize);
                FileManager.WriteChunks(chunks);
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
