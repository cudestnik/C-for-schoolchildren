using System;
using System.Windows.Forms;
using System.Drawing;

class FormWithWorkingButton : Form
{
    Button mrButton;
    // Метод-конструктор нашего класса
    public FormWithWorkingButton()
    {
        // Указываем заголовок окна
        this.Text = "Форма с работающей кнопкой!";

        // Добавляем кнопку и привязываем ее к обработчику события
        mrButton = new Button();
        mrButton.Text = "Нажми меня";
        mrButton.Top = 100;
        mrButton.Left = 100;
        mrButton.Height = 50;
        mrButton.Width = 70;
        mrButton.Click += new System.EventHandler(mrButton_Click);
        this.Controls.Add(mrButton);
    }

    static void Main()
    {
        // Создаем и запускаем форму
        Application.Run(new FormWithWorkingButton());
    }

    // Обработчик события, срабатывающий при нажатии кнопки
    void mrButton_Click(object sender, EventArgs e)
    {
        // Изменяем заголовок окна
        mrButton.Text = "Кнопка была нажата!";
    }
}

