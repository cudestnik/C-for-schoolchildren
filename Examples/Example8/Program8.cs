using System;
using System.Windows.Forms;
using System.Drawing;

class PictureDisplayer : Form
{
    Bitmap image1;
    PictureBox pictureBox1;

    // Метод-конструктор нашего класса
    public PictureDisplayer()
    {
        // Указываем размеры и заголовок окна

        this.Text = "Искусство аборигенов";
        this.Size = new Size(302, 240);

        // Подготавливаем поле для размещения изображения

        pictureBox1 = new PictureBox();
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        pictureBox1.ClientSize = new Size(300, 196);

        // Добавляем изображение в элемент PictureBox

        image1 = new Bitmap(@"../../images/Iskusstvo.jpg");
        pictureBox1.Image = (Image)image1;

        // Добавляем PictureBox (с изображением) на форму

        this.Controls.Add(pictureBox1);

    }

    static void Main()
    {
        // Создаем и запускаем форму
        Application.Run(new PictureDisplayer());
    }

}
