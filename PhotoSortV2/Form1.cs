using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoSortV2
{
    public partial class Form1 : Form
    {

        private string InPath;
        private string OutPath;
        private string FileName;
        private string LastStored;
        private string LastStoredFilename; 

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Open FTS Website
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Open FTS WEBSITE
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "1")
            {
                MessageBox.Show("You must select an input directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yesButton.PerformClick();
            }
            if (e.KeyCode.ToString() == "2")
            {
                maybeButton.PerformClick();
            }
            if (e.KeyCode.ToString() == "3")
            {
                noButton.PerformClick();
            }
        }


        private void inputButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.DirectoryInfo indir = new System.IO.DirectoryInfo(folderBrowserDialog1.SelectedPath);

                System.IO.FileInfo[] Images = indir.GetFiles("*.jpg");
                string parentheses = "/";
                // IF ARRAY IS NULL THROW ERROR 
                if (Images == null)
                {
                    MessageBox.Show("You must select a directory with images in it.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InPath = folderBrowserDialog1.SelectedPath + parentheses;
                    if (Images.Length < 1)
                    {
                        MessageBox.Show("You must select a directory with images in it.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        FileName = Convert.ToString(Images[0]);
                        pictureBox1.Load(InPath + FileName);
                    }
                    
                }
               
                
            }
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                System.IO.DirectoryInfo outdir = new System.IO.DirectoryInfo(folderBrowserDialog2.SelectedPath);

                string parentheses = "/";
                OutPath = outdir + parentheses;
                
                if (!(System.IO.Directory.Exists(OutPath + "Yes"))) 
                {
                    System.IO.Directory.CreateDirectory(OutPath + "Yes");
                }
                if (!(System.IO.Directory.Exists(OutPath + "Maybe")))
                {
                    System.IO.Directory.CreateDirectory(OutPath + "Maybe");
                }
                if (!(System.IO.Directory.Exists(OutPath + "No")))
                {
                    System.IO.Directory.CreateDirectory(OutPath + "No");
                }
                MessageBox.Show("All required directories were sucessfully created in the output destination specified.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            string source = InPath + FileName;
            string dest = OutPath + "yes/" + FileName;
            pictureBox1.Load(System.IO.Directory.GetCurrentDirectory() + "/Resources/ftslogo.png");
            if(InPath == null) 
            {
                MessageBox.Show("You must select an input directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (OutPath == null)
            {
                MessageBox.Show("You must select an output directory first!" , "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.IO.File.Move(source, dest);
                LastStored = dest;
                LastStoredFilename = FileName;
                System.IO.DirectoryInfo indir = new System.IO.DirectoryInfo(InPath);

                 System.IO.FileInfo[] Images = indir.GetFiles("*.jpg");

                 if (Images.Length < 1)
               {
                  MessageBox.Show("Sorting is Complete!", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                 }
               else
              {
                  FileName = Convert.ToString(Images[0]);
                   pictureBox1.Load(InPath + FileName);
               }
            }

        }

        private void maybeButton_Click(object sender, EventArgs e)
        {
            string source = InPath + FileName;
            string dest = OutPath + "maybe/" + FileName;
            pictureBox1.Load(System.IO.Directory.GetCurrentDirectory() + "/Resources/ftslogo.png");
            if (InPath == null)
            {
                MessageBox.Show("You must select an input directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (OutPath == null)
            {
                MessageBox.Show("You must select an output directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.IO.File.Move(source, dest);
                LastStored = dest;
                LastStoredFilename = FileName;

                System.IO.DirectoryInfo indir = new System.IO.DirectoryInfo(InPath);

                System.IO.FileInfo[] Images = indir.GetFiles("*.jpg");

                if (Images.Length < 1)
                {
                    MessageBox.Show("Sorting is Complete!", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    FileName = Convert.ToString(Images[0]);
                    pictureBox1.Load(InPath + FileName);
                }
            }
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            string source = InPath + FileName;
            string dest = OutPath + "no/" + FileName;
            pictureBox1.Load(System.IO.Directory.GetCurrentDirectory() + "/Resources/ftslogo.png");
            if (InPath == null)
            {
                MessageBox.Show("You must select an input directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (OutPath == null)
            {
                MessageBox.Show("You must select an output directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.IO.File.Move(source, dest);
                LastStored = dest;
                LastStoredFilename = FileName;

                System.IO.DirectoryInfo indir = new System.IO.DirectoryInfo(InPath);

                System.IO.FileInfo[] Images = indir.GetFiles("*.jpg");

                if (Images.Length < 1)
                {
                    MessageBox.Show("Sorting is Complete!", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    FileName = Convert.ToString(Images[0]);
                    pictureBox1.Load(InPath + FileName);
                }
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (LastStored == null)
            {
                MessageBox.Show("There is nothing to undo! You can't undo more than once!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.IO.File.Move(LastStored, InPath + LastStoredFilename);
                LastStored = null;
                MessageBox.Show("The image has been restored sucessfully! You can sort it next", "Yay!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 49)
            {
                MessageBox.Show("You must select an input directory first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yesButton.PerformClick();
            }
            if (e.KeyChar == 50)
            {
                maybeButton.PerformClick();
            }
            if (e.KeyChar == 51)
            {
                noButton.PerformClick();
            }
        }
    }
}
