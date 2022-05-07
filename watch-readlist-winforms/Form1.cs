using System;
using System.Collections;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace watch_readlist_winforms
{
    public partial class Form1 : MaterialForm
    {
        Queue anime_queue = new Queue();
        Queue manga_queue = new Queue();

        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green800, Primary.Green500, Accent.LightGreen700, TextShade.WHITE);
        }

        /// <summary>
        /// Clicking the anime button from the home tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnime_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabAnime;

        /// <summary>
        /// Clicking the manga button from the manga tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManga_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabManga;

        /// <summary>
        /// Clicking the add button from the anime tab.
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
        /// Clicking the remove button from anime tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimeClear_Click(object sender, EventArgs e) => tbAnime.ResetText();

        /// <summary>
        /// Clicking the remove top button from anime tab.
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
        /// Clicking the show top button from anime tab.
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
        /// Clicking the count button from anime tab.
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
        /// Clicking the clear all button from anime tab.
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

        /// <summary>
        /// Clicking the add button from manga tab.
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
        /// Clicking the clear button from manga tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMangaClear_Click(object sender, EventArgs e) => tbManga.ResetText();

        /// <summary>
        /// Clicking the remove top button from manga tab.
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
        /// Clicking the show top button from manga tab.
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
        /// Clicking the count button from manga tab.
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
        /// Clicking the clear all button from manga tab.
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

        /// <summary>
        /// Clicking the clear history button from history tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryClearAll_Click(object sender, EventArgs e) => lstbHistory.Items.Clear();
    }
}