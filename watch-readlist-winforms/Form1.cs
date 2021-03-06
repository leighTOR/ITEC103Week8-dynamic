using System;
using System.Collections;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace watch_readlist_winforms
{
    /// <summary>
    /// A desktop application that lists your want to 
    /// watch & read, already read manga, and watched anime.
    /// This project implemented a dynamic data structure which
    /// is queue to demonstrate how this dynamic works. 
    /// </summary>
    public partial class Form1 : MaterialForm
    {
        Queue anime_queue = new Queue();
        Queue manga_queue = new Queue();

        #region Constructors
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green800, Primary.Green500, Accent.LightGreen700, TextShade.WHITE);
        }
        #endregion

        #region Home tab
        /// <summary>
        /// Going to anime tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnime_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabAnime;

        /// <summary>
        /// Going to manga tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManga_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabManga;
        #endregion

        #region Anime tab
        /// <summary>
        /// Adding a anime title from textbox to listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeAdd_Click(object sender, EventArgs e)
        {
            if (tbAnime.Text != "")
            {
                lstbAnime.Items.Add(new MaterialListBoxItem(tbAnime.Text));
                anime_queue.Enqueue(tbAnime.Text);
            }
            else
                MessageBox.Show("Empty textbox.");
        }

        /// <summary>
        /// Pressing the enter key to trigger the add button from anime tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAnime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAnimeAdd_Click(sender, e);
                tbAnime.ResetText();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Clearing the anime title textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeClear_Click(object sender, EventArgs e) => tbAnime.ResetText();

        /// <summary>
        /// Adding the top title to history listbox then
        /// removing it from the manga listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lstbHistory.Items.Add(lstbAnime.Items[0]); // moving it to history listbox.
                lstbAnime.Items.RemoveAt(0);
                anime_queue.Dequeue();
                
            }
            catch
            {
                MessageBox.Show("List empty.");
            }
        }

        /// <summary>
        /// Showing the top title from listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeShow_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Top: {anime_queue.Peek()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Counting all the titles inside the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeCount_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Count: {anime_queue.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Adding all the titles to history listbox then
        /// clearing all the manga listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeClearAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lstbAnime.Items)
                lstbHistory.Items.Add(item); // moving it to history listbox.

            lstbAnime.Items.Clear();
            anime_queue.Clear();
        }
        #endregion

        #region Manga tab
        /// <summary>
        /// Adding a manga title from textbox to listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaAdd_Click(object sender, EventArgs e)
        {
            if (tbManga.Text != "")
            {
                lstbManga.Items.Add(new MaterialListBoxItem(tbManga.Text));
                manga_queue.Enqueue(tbManga.Text);
            }
            else
                MessageBox.Show("Empty textbox.");
        }

        /// <summary>
        /// Pressing the enter key to trigger the add button from manga tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbManga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMangaAdd_Click(sender, e);
                tbManga.ResetText();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Clearing the manga title textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaClear_Click(object sender, EventArgs e) => tbManga.ResetText();

        /// <summary>
        /// Adding the top manga title to history listbox
        /// then removing the it from manga listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lstbHistory.Items.Add(lstbManga.Items[0]); // moving it to history listbox.
                lstbManga.Items.RemoveAt(0);
                manga_queue.Dequeue();
            }
            catch
            {
                MessageBox.Show("List empty.");
            }
        }

        /// <summary>
        /// Showing the top manga title from the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaShow_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Top: {manga_queue.Peek()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Counting all the manga titles inside the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaCount_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Count: {manga_queue.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Transfering all the titles to history listbox
        /// then clearing the manga listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaClearAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lstbManga.Items)
                lstbHistory.Items.Add(item);  // moving it to history listbox.

            lstbManga.Items.Clear();
            manga_queue.Clear();
        }
        #endregion

        /// <summary>
        /// Clearing all the titles inside the history listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryClearAll_Click(object sender, EventArgs e) => lstbHistory.Items.Clear();
    }
}