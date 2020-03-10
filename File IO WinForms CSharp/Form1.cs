using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_IO_WinForms_CSharp
{
    public partial class FormReadWrite : Form
    {
        List<string> movies = new List<string>();
        public FormReadWrite()
        {
            InitializeComponent();
        }

      
     

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (movies.Contains(txtAddWords.Text.Trim()))
                MessageBox.Show("Movie already in list");
            else if (txtAddWords.Text.Trim().Length == 0)
                MessageBox.Show("Please enter a movie name");
            else
            {
                movies.Add(txtAddWords.Text.Trim());
                txtAddWords.Text = "";
                lstMovies.DataSource = null;
                lstMovies.DataSource = movies;
            }
                

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            movies.Remove((string)lstMovies.SelectedItem);
            lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            movies.Sort();
            lstMovies.DataSource = null;
            lstMovies.DataSource = movies;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            
            if (ofdMovie.ShowDialog() == DialogResult.OK)
            {
                foreach (string movie in File.ReadLines(ofdMovie.FileName, Encoding.UTF8))
                {
                    movies.Add(movie);
                }

                lstMovies.DataSource = null;
                lstMovies.DataSource = movies;

            }
        }
    }
}
