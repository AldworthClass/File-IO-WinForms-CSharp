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
            ofdMovie.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";    //Will filter text files by default
            ofdMovie.RestoreDirectory = true;   //Will open to previousley selected directory
            ofdMovie.FileName = "movies";       //the filename displayed by default in the Dialog Box
            if (ofdMovie.ShowDialog() == DialogResult.OK)   //Only
            {
                movies.Clear();
                foreach (string movie in File.ReadLines(ofdMovie.FileName, Encoding.UTF8))
                {
                    movies.Add(movie);
                }
                lstMovies.DataSource = null;
                lstMovies.DataSource = movies;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ofdMovie.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofdMovie.RestoreDirectory = true;
            ofdMovie.FileName = "movies";
            ofdMovie.DefaultExt = ".txt";
            if (ofdMovie.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(sfdMovie.FileName);
                foreach (string movie in movies)
                    writer.WriteLine(movie);
                writer.Close();
            }

        }
    }
}
