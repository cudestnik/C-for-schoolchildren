using System;
using System.Windows.Forms;
using System.Drawing;

class FunWithTheMouse : Form
{
    // Объявляем объекты, доступные для разных методов

    PictureBox pictureBox1;
    Label label1;
    Point spotClicked;

    // Метод-конструктор нашего класса
    public FunWithTheMouse()
    {
        // Задаем размеры окна

        this.Size = new Size(640, 480);

        // Загружаем рисунок в элемент PictureBox и вставляем в форму

        pictureBox1 = new PictureBox();
        pictureBox1.Image = (Image)new Bitmap(@"../../images/Dog.bmp");
        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        pictureBox1.Dock = DockStyle.Fill;
        this.Controls.Add(pictureBox1);

        // Добавляем метку с инструкциями в нижнюю часть экрана

        label1 = new Label();
        label1.BackColor = Color.Wheat;
        label1.Dock = DockStyle.Bottom;
        label1.Text =
        "При нажатой левой кнопке мыши можно рисовать прямоугольники. " +
        "Нажатая правая кнопка изменяет яркость выделенного прямоугольника " +
        "Нажав SHIFT и перемещая мышь, рисуем желтые кружки.";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        this.Controls.Add(label1);

        // Привязываем PictureBox к обработчикам событий мыши

        this.pictureBox1.MouseDown += new MouseEventHandler(MouseButtonIsDown);
        this.pictureBox1.MouseUp += new MouseEventHandler(MouseButtonIsUp);
        this.pictureBox1.MouseMove += new MouseEventHandler(TheMouseMoved);
    }

    // Обработчик событий, срабатывающий при ПЕРЕМЕЩЕНИИ мыши
    public void TheMouseMoved(object sender, MouseEventArgs e)
    {
        // Если на клавиатуре нажата клавиша SHIFT
        if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
        {
            // Подготовка области рисования на изображении
            System.Drawing.Graphics g = this.pictureBox1.CreateGraphics();

            // Используем желтое перо
            System.Drawing.Pen yellowPen = new System.Drawing.Pen(Color.Yellow, 3);

            // Рисуем окружность (эллипс, вписанный в квадрат)
            // Верхний левый угол квадрата имеет координаты X и Y текущего положения мыши
            g.DrawEllipse(yellowPen, e.X, e.Y, 40, 40);

            // Очистка
            g.Dispose();
        }
    }

    // Обработчик событий, срабатывающий при НАЖАТИИ кнопки мыши
    public void MouseButtonIsDown(object sender, MouseEventArgs e)
    {
        // Запоминаем точку, в которой произошло нажатие кнопки мыши. Когда
        // кнопка будет отпущена, нам понадобятся ее координаты

        spotClicked.X = e.X;// горизонтальная координата
        spotClicked.Y = e.Y;// вертикальная координата
    }

    // Обработчик событий, срабатывающий при ОТЖАТИИ кнопки мыши
    public void MouseButtonIsUp(object sender, MouseEventArgs e)
    {
        /* Пользователь отпустил кнопку мыши! */

        // Создаем прямоугольник (пока он еще не виден), ограничивающий
        // область изображения, с которой пользователь будет работать

        Rectangle r = new Rectangle();

        // Левый верхний угол соответствует точке, в которой была нажата кнопка мыши
        // Мы сохранили ее координаты с помощью описанного выше метода

        r.X = spotClicked.X;
        r.Y = spotClicked.Y;

        // Ширина и высота прямоугольника вычисляется
        // путем вычитания начальных координат мыши (в точке нажатия)
        // из текущих координат (в точке отжатия кнопки)

        r.Width = e.X - spotClicked.X;
        r.Height = e.Y - spotClicked.Y;

        if (e.Button == MouseButtons.Left)
        {
            /* Если была нажата и отпущена левая кнопка мыши
            рисуем видимый контур прямоугольника */

            // Подготовка области рисования на изображении

            Graphics g = this.pictureBox1.CreateGraphics();

            // Рисуем красный контур прямоугольника

            Pen redPen = new Pen(Color.Red, 2);
            g.DrawRectangle(redPen, r);
        }
        else
        {
            // Если была нажата другая кнопка, вызываем более сложный
            // метод, подсвечивающий область изображения

            ChangeLightness(r);
        }
    }

    // Метод, увеличивающий яркость выбранного участка изображения
    // путем увеличения яркости каждого пикселя этого участка
    public void ChangeLightness(Rectangle rect)
    {
        int newRed, newGreen, newBlue;
        Color pixel;

        // Копируем изображение, загруженное в PictureBox

        System.Drawing.Bitmap picture = new Bitmap(this.pictureBox1.Image);

        // Поскольку операция увеличения яркости может занять много времени,
        // необходимо предупредить об этом пользователя, если выбран большой участок

        if ((rect.Width > 150) || (rect.Height > 150))
        {

            DialogResult result = MessageBox.Show(
                "Выделенная область велика! " +
            " Изменение яркости может потребовать значительного времени!",
            "Warning", MessageBoxButtons.OKCancel);

            // При нажатии кнопки Cancel (Отмена) выходим из метода
            // и возвращаемся к месту его вызова
            if (result == DialogResult.Cancel) return;
        }

        /* Перебираем последовательно все пиксели данного участка
        и удваиваем значение яркости компонент RGB пикселей */

        // Перебор по горизонтали слева направо ...

        for (int x = rect.X; x < rect.X + rect.Width; x++)
        {
            // и по вертикали сверху вниз ...

            for (int y = rect.Y; y < (rect.Y + rect.Height); y++)
            {
                // Считываем текущий пиксель

                pixel = picture.GetPixel(x, y);

                // Увеличиваем яркость цветовых компонент пикселя

                newRed = (int)Math.Round(pixel.R * 2.0, 0);
                if (newRed > 255) newRed = 255;
                newGreen = (int)Math.Round(pixel.G * 2.0, 0);
                if (newGreen > 255) newGreen = 255;
                newBlue = (int)Math.Round(pixel.B * 2.0, 0);
                if (newBlue > 255) newBlue = 255;

                // Присваиваем пикселю новые цветовые значения

                picture.SetPixel
                (x, y, Color.FromArgb(
                (byte)newRed, (byte)newGreen, (byte)newBlue));
            }
        }

        // Помещаем измененную копию изображения в PictureBox
        // чтобы изменения отобразились на экране

        this.pictureBox1.Image = picture;

    }

    static void Main()
    {
        // Создаем экземпляр класса формы

        Application.Run(new FunWithTheMouse());
    }
}
