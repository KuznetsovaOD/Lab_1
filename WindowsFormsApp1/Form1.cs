using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private void button1_Click(object sender, EventArgs e)
        {
            CirqRectangle cirqRectangle = new CirqRectangle(getColor());
            try
            {
                pictureBox1.Image = cirqRectangle.Draw(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)) ;
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }

            label1.Text = cirqRectangle.String("Скруглённый прямоугольник");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Ellipse circle = new Ellipse(getColor());
            try
            {
                pictureBox1.Image = circle.Draw(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text));
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            label1.Text = circle.String("Круг");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse(getColor());
            try
            {
                pictureBox1.Image = ellipse.Draw(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            label1.Text = ellipse.String("Эллипс");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Rectangle square = new Rectangle(getColor());
            try
            {
                pictureBox1.Image = square.Draw(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text));
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            label1.Text = square.String("Квадрат");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(getColor());
            try
            {
                pictureBox1.Image = rectangle.Draw(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            label1.Text = rectangle.String("Прямоугольник");
        }
        public int getHeight()
        {
            return pictureBox1.Height;
        }
        public int getWidth()
        {
            return pictureBox1.Width;
        }
        public Color getColor()
        {
            Color color;
            {
            if (radioButton1.Checked) return color = Color.Red;
            else if (radioButton2.Checked) return color = Color.Yellow;
            else if (radioButton3.Checked) return color = Color.Green;
            else return color = Color.Purple;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            textBox1.Text = "200";
            textBox2.Text = "100";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }



    abstract class Shape                           //Абстрактный класс фигуры
    {
        public int x1;
        public int y1;
        public SolidBrush pen;
        public SolidBrush myPen;
        public Shape()
        {
            x1 = 40;
            y1 = 40;
            pen = new SolidBrush(Color.White);
        }
        public string String(string nameShape) 
        {
            return nameShape;
        }
        abstract public Image Draw(int posX, int posY);
    }


    class Ellipse : Shape                         //класс для круга и эллипса
    {
        public Ellipse(Color color)
        {
            myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillEllipse(myPen, x1, y1, posX, posY);
            return pictureBox;
        }
    }


    class Rectangle : Shape                       //класс для квадрата и прямоугольника
    {
        public Rectangle(Color color)
        {
            myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillRectangle(myPen, x1, y1, posY, posX);
            return pictureBox;
        }
    }


    class CirqRectangle : Shape                   //класс для скруглённого прямоугольника    
    {
        public CirqRectangle(Color color)
        {
           myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Pen pen2 = new Pen(Color.White, 30);
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillRectangle(myPen, x1, y1, posX, posY);
            graph.DrawEllipse(pen2, x1 - 20, y1 - 50, posX + 40, posY + 100);
            return pictureBox;
        }
    }
}
