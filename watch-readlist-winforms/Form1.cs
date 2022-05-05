using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace watch_readlist_winforms
{
    public partial class Form1 : MaterialForm
    {
        Queue queue = new Queue();
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green800, Primary.Green500, Accent.LightGreen700, TextShade.WHITE);
        }

        private void btnAnime_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabAnime;

        private void btnManga_Click(object sender, EventArgs e) => tbctrlMenu.SelectedTab = tabManga;

        private void btnAnimeAdd_Click(object sender, EventArgs e)
        {
            if (tbAnime.Text != "")
            {
                lstbAnime.Items.Add(new MaterialListBoxItem(tbAnime.Text));
                queue.Enqueue(tbAnime.Text);
            }
            else
            {
                MessageBox.Show("Empty textbox.");
            }
        }

        private void btnAnimeClear_Click(object sender, EventArgs e)
        {
            tbAnime.ResetText();
        }

        private void btnAnimeRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lstbAnime.Items.RemoveAt(0);
                queue.Dequeue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAnimeShow_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Top: {queue.Peek()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAnimeCount_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Count: {queue.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAnimeClearAll_Click(object sender, EventArgs e)
        {
            lstbAnime.Items.Clear();
            queue.Clear();
        }
    }
}
