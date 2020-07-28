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

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        // Forma całej aplikacji 
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // button odpowiedzialny za odtwarzanie playlisty
        private void button1_Click(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylist Playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            // dodanie wszystkich wybranych piosenek i utworzenie playlisty
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                int ii = 1;
                media = axWindowsMediaPlayer1.newMedia(listView1.Items[i].SubItems[ii].Text);
                Playlist.appendItem(media);
                ii++;

                axWindowsMediaPlayer1.currentPlaylist = Playlist;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        // button odpowiedzialny za załadowanie plików mp3 do listView
        private void BtLadFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // wybranie głównej ścieżki do szukania plików jako dysk C
            openFileDialog1.InitialDirectory = "c:\\";
            // Ustawienie filtra na wyszukiwanie między innymi plików mp3
            openFileDialog1.Filter = "MP3 Audio File (*mp3)|*.mp3|Windows Media Audio File (*.wma)|*.wma|WAV Audio File (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // wyswietlenie sciezki i nazwy plikow
                            string[] fileNameAndPath = openFileDialog1.FileNames;
                            string[] filename = openFileDialog1.SafeFileNames;

                            for (int i = 0; i < openFileDialog1.SafeFileNames.Count(); i++)
                            {
                                string[] saLvwItem = new string[2];

                                saLvwItem[0] = filename[i];
                                saLvwItem[1] = fileNameAndPath[i];

                                ListViewItem Lvi = new ListViewItem(saLvwItem);

                                listView1.Items.Add(Lvi);

                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Nie można załadować plików");
            }
            }

        }
        // list view wyświetlające załadowane pliki
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // list view odtwarzające wybrany plik mp3
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string selectedFile = listView1.FocusedItem.SubItems[1].Text;

            axWindowsMediaPlayer1.URL = selectedFile;
        }
        // okno Windows media player odtwarzające mp3
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
