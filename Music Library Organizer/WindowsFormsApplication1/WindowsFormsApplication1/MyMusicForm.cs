using SongLibrary;
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
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class MyMusicForm : Form
    {

        List<SongInfo> songLib = new List<SongInfo>();
        BindingList<SongInfo> bindingSongLib;

        public MyMusicForm()
        {
            InitializeComponent();

            

            bindingSongLib = new BindingList<SongInfo>(songLib);
            bindingSongLib.RaiseListChangedEvents = true;
            bindingSongLib.AllowNew = true;
            bindingSongLib.AllowEdit = true;
            this.listBox1.DataSource = bindingSongLib;
            this.listBox1.DisplayMember = "Title";

            this.comboBox1.DataSource = Enum.GetValues(typeof(SongLibrary.Label));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MyVideoForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void saveLibraryDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void newSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongInfo newSong = new SongInfo();
            bindingSongLib.Add(newSong);
            this.listBox1.SetSelected(songLib.Count - 1, true);
            this.textBox1.Text = "Enter a song title ...";
            this.label3.Text = "Producer";
            this.textBox2.Text= "Enter Producer's full name";
            this.numericUpDown1.Value = 1977;



        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SongInfo song = (SongInfo)this.listBox1.SelectedItem;
            if (song != null)
            {
                this.textBox1.Text = song.Title;
                this.textBox2.Text = song.Producer;
                this.label3.Text = "Producer";

                this.comboBox1.SelectedIndex = (int)song.RecordLabel;
                this.numericUpDown1.Value = song.Year;
                this.dateTimePicker1.Value = new DateTime(2010, 1, 1, song.Length.Hours, song.Length.Minutes, song.Length.Seconds);
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            SongInfo selectedSong = this.listBox1.SelectedItem as SongInfo;
            if (selectedSong != null)
            {
                selectedSong.Title = this.textBox1.Text;
                selectedSong.Producer = this.textBox2.Text;
                selectedSong.RecordLabel = (SongLibrary.Label)this.listBox1.SelectedIndex;
                selectedSong.Year = (int)this.numericUpDown1.Value;
                selectedSong.Length = new TimeSpan(this.dateTimePicker1.Value.Hour,
                this.dateTimePicker1.Value.Minute, this.dateTimePicker1.Value.Second);
                //selectedSong.Review = this.richTextBox1.Rtf;
                bindingSongLib.ResetItem(index);
            }

        //    this.textBox1.Text = "Enter a song title ...";
            this.label3.Text = "Producer";
        //    this.textBox2.Text = "Enter Producer's full name";
            this.numericUpDown1.Value = 1970;
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveLibraryDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(songLib.GetType());
                using (TextWriter w = new StreamWriter(saveLibraryDialog.FileName))
                {
                    s.Serialize(w, songLib);
                }
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.openLibraryDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(songLib.GetType());
                using (TextReader reader = new StreamReader(openLibraryDialog.FileName))
                {
                    List<SongInfo> newVideos = (List<SongInfo>)s.Deserialize(reader);
                    foreach (SongInfo video in newVideos)
                        bindingSongLib.Add(video);
                }
            }

        }

       
    }

}
