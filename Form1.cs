using System.Diagnostics;
using System.Drawing;

namespace DesignApp
{
    public partial class Form1 : Form
    {
        bool isDrag = false;
        int detailindex;
        Point start = new Point(0, 0);
        string id, itemname;
        List<Bitmap> detail = new List<Bitmap> { null, null, null, null, null, null, null, null };
        List<Image> GunImage = new List<Image> { Image.FromFile("res/GUN/M4A1.png"), Image.FromFile("res/GUN/M4A4.png"), Properties.Resources.big };
        List<Image> CarImage = new List<Image>();
        List<Image> PlaneImage = new List<Image>();
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap AddPixelToImage(Bitmap original, Color pixelColor)
        {
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(original, 0, 0, original.Width, original.Height);
            }
            newImage.SetPixel(0, 0, pixelColor);
            newImage.SetPixel(original.Width - 1, 0, pixelColor);
            newImage.SetPixel(0, original.Height - 1, pixelColor);
            newImage.SetPixel(original.Width - 1, original.Height - 1, pixelColor);
            return newImage;
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start.X, p.Y - start.Y);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            start = new Point(e.X, e.Y);
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            start = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start.X, p.Y - start.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("確定關閉?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> Styles = new List<string> { "槍枝", "車輛", "飛機" };
            comboBox1.Items.AddRange(Styles.ToArray());
            comboBox1.SelectedIndex = 0;
            //car
            CarImage.Add(Properties.Resources.big);
            //plane
            PlaneImage.Add(Image.FromFile("res/PLANE/1f2a.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/2f22a.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/3f15e.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/4F18F.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/5f35c.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/6su34.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/7su47.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/8su57.png"));
            PlaneImage.Add(Image.FromFile("res/PLANE/9rafaleb.png"));
            PlaneImage.Add(Properties.Resources.big);

            textBox1.Visible = false;
            label4.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    load_gun();
                    break;
                case 1:
                    load_car();
                    break;
                case 2:
                    load_plane();
                    break;
            }
        }

        private void load_gun()
        {
            comboBox2.Items.Clear();
            List<String> gunlist = new List<String> { "M4A1-S", "M4A4", "其他" };
            comboBox2.Items.AddRange(gunlist.ToArray());
            comboBox2.SelectedIndex = 0;
        }
        private void load_car()
        {
            comboBox2.Items.Clear();
            List<String> carlist = new List<String> { "暫無" };
            comboBox2.Items.AddRange(carlist.ToArray());
            comboBox2.SelectedIndex = 0;
        }
        private void load_plane()
        {
            comboBox2.Items.Clear();
            List<String> planelist = new List<String> { "F2A", "F22A", "F15E", "FA18F", "F35C", "SU34", "SU47", "SU57", "RafaleB", "其他" };
            comboBox2.Items.AddRange(planelist.ToArray());
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label4.Visible = false;
            itemname = comboBox2.SelectedItem.ToString();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = GunImage[comboBox2.SelectedIndex];
                    label3.Text = $"長:{GunImage[comboBox2.SelectedIndex].Width} 寬:{GunImage[comboBox2.SelectedIndex].Height}";
                    switch (comboBox2.SelectedIndex)
                    {
                        case 2:
                            textBox1.Visible = true;
                            label4.Visible = true;
                            break;
                    }
                    break;
                case 1:
                    pictureBox1.Image = CarImage[comboBox2.SelectedIndex];
                    label3.Text = $"長:{CarImage[comboBox2.SelectedIndex].Width} 寬:{CarImage[comboBox2.SelectedIndex].Height}";
                    break;
                case 2:
                    pictureBox1.Image = PlaneImage[comboBox2.SelectedIndex];
                    label3.Text = $"長:{PlaneImage[comboBox2.SelectedIndex].Width} 寬:{PlaneImage[comboBox2.SelectedIndex].Height}";
                    switch (comboBox2.SelectedIndex)
                    {
                        case 9:
                            textBox1.Visible = true;
                            label4.Visible = true;
                            break;
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                MessageBox.Show("請先導出圖片!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = $"客製化 {itemname}";
                Form2 form2 = new Form2(name, id);
                form2.Show();
                id = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            Color color = Color.FromArgb(r, g, b);
            pictureBox1.Image = AddPixelToImage(new Bitmap(pictureBox1.Image), color);
            id = r.ToString("D3") + g.ToString("D3") + b.ToString("D3");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "儲存圖片檔案";
            saveFileDialog.Filter = "PNG File(*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("存檔成功!", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Trace.Write(id);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File(*.png)|*.png|JPG File(*.jpg)|*.jpg|BMP File(*.bmp)|*.bmp|All File(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image checkimage = Image.FromFile(openFileDialog.FileName);
                Bitmap bmp = new Bitmap(checkimage);
                Color pixel1 = bmp.GetPixel(0, 0);
                Color pixel2 = bmp.GetPixel(checkimage.Width - 1, 0);
                Color pixel3 = bmp.GetPixel(0, checkimage.Height - 1);
                Color pixel4 = bmp.GetPixel(checkimage.Width - 1, checkimage.Height - 1);
                string id1 = pixel1.R.ToString("D3") + pixel1.G.ToString("D3") + pixel1.B.ToString("D3");
                string id2 = pixel2.R.ToString("D3") + pixel2.G.ToString("D3") + pixel2.B.ToString("D3");
                string id3 = pixel3.R.ToString("D3") + pixel3.G.ToString("D3") + pixel3.B.ToString("D3");
                string id4 = pixel4.R.ToString("D3") + pixel4.G.ToString("D3") + pixel4.B.ToString("D3");
                if (id1 == id2 && id2 == id3 && id3 == id4)
                {
                    Clipboard.SetText(id1);
                    MessageBox.Show($"檢驗合格，編號為{id1}\r\n已為您複製編號", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Clipboard.SetText($"疑似有更動痕跡!\r\n左上:{id1}\r\n右上:{id2}\r\n左下:{id3}\r\n右下:{id4}");
                    MessageBox.Show($"疑似有更動痕跡!\r\n左上:{id1}\r\n右上:{id2}\r\n左下:{id3}\r\n右下:{id4}\r\n已為您複製錯誤訊息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "選擇塗裝檔案";
            openFileDialog.Filter = "PNG File(*.png)|*.png|JPG File(*.jpg)|*.jpg|BMP File(*.bmp)|*.bmp|All File(*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            label4.Visible = true;
            textBox1.Visible = true;
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            itemname = textBox1.Text;
        }
    }
}