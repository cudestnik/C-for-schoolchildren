using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Xml;

class FormWithManyControls : Form
{
    TreeView treeView1;
    Panel panel1;
    CheckBox checkBox1, checkBox2;
    RadioButton radioButton1, radioButton2;
    ListBox listBox1;

    // Метод-конструктор нашего класса
    public FormWithManyControls()
    {
        // Указываем размеры и заголовок окна

        this.Text = "Форма, включающая различные элементы управления!";
        this.Height = 800; this.Width = 900;


        // Добавляем элемент TreeView в качестве своеобразного меню

        treeView1 = new TreeView();
        treeView1.BackColor = Color.BurlyWood;
        treeView1.Dock = DockStyle.Left;
        treeView1.AfterSelect +=
        new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);

        TreeNode tn = new TreeNode("Элементы");
        tn.Expand();

        tn.Nodes.Add(new TreeNode("[Очистить]"));
        tn.Nodes.Add(new TreeNode("Label"));
        tn.Nodes.Add(new TreeNode("Button"));
        tn.Nodes.Add(new TreeNode("CheckBox"));
        tn.Nodes.Add(new TreeNode("RadioButton"));
        tn.Nodes.Add(new TreeNode("ListBox"));
        tn.Nodes.Add(new TreeNode("TextBox"));
        tn.Nodes.Add(new TreeNode("TabControl"));
        tn.Nodes.Add(new TreeNode("DataGridView"));
        tn.Nodes.Add(new TreeNode("MainMenu"));
        tn.Nodes.Add(new TreeNode("ToolBar"));
        tn.Nodes.Add(new TreeNode("PictureBox"));
        tn.Nodes.Add(new TreeNode("RichTextBox"));

        treeView1.Nodes.Add(tn);

        this.Controls.Add(treeView1);

        // Добавляем панель для размещения остальных элементов управления

        panel1 = new Panel();
        panel1.Dock = DockStyle.Right;
        panel1.BorderStyle = BorderStyle.Fixed3D;
        panel1.Width = this.Width - treeView1.Width;

        this.Controls.Add(panel1);
    }

    // Обработчик событий, срабатывающий при выборе одного из узлов дерева TreeView
    private void treeView1_AfterSelect
    (object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        // Выполнение соответствующего действия при выборе любого из узлов

        if (e.Node.Text == "[Очистить]")
        {
            // Удаляем с панели все элементы управления
            panel1.Controls.Clear();
        }
        else if (e.Node.Text == "Button")
        {
            // Добавляем на панель кнопку

            Button button1 = new Button();
            button1.Text = "Нажми меня!";
            button1.Location = new Point(300, 20);
            button1.Width = 120;
            button1.Height = 40;
            button1.Click += new EventHandler(button1_Click);

            panel1.Controls.Add(button1);
        }
        else if (e.Node.Text == "Label")
        {
            // Добавляем на панель метку

            Label label1 = new Label();
            label1.Text =
            "Это метка. Используется для вывода текста на экран!";
            
            label1.Location = new Point(180, 70);
            label1.Width = 400;
            label1.Click += new EventHandler(label1_Click);

            panel1.Controls.Add(label1);
        }
        else if (e.Node.Text == "CheckBox")
        {
            // Добавляем на панель несколько флажков

            checkBox1 = new CheckBox();
            checkBox1.Text = "Я способный!";
            checkBox1.Location = new Point(20, 40);
            checkBox1.Width = 150;
            checkBox1.CheckedChanged +=
            new EventHandler(CheckBox_CheckedChanged);
            panel1.Controls.Add(checkBox1);

            checkBox2 = new CheckBox();
            checkBox2.Text = "Я скромный!";
            checkBox2.Location = new Point(20, 80);
            checkBox2.Width = 150;
            checkBox2.CheckedChanged +=
            new EventHandler(CheckBox_CheckedChanged);
            panel1.Controls.Add(checkBox2);
        }
        else if (e.Node.Text == "RadioButton")
        {
            // Добавляем на панель несколько переключателей

            radioButton1 = new RadioButton();
            radioButton1.Text = "Я добрый!";
            radioButton1.Location = new Point(20, 120);
            radioButton1.Width = 150;
            radioButton1.Height = 30;
            //radioButton1.Size = new Size(20, 100);

            radioButton1.CheckedChanged +=
            new EventHandler(RadioButton_CheckedChanged);

            panel1.Controls.Add(radioButton1);

            radioButton2 = new RadioButton();
            radioButton2.Text = "Я трудолюбивый!";
            radioButton2.Location = new Point(20, 160);
            radioButton2.Width = 150;
            radioButton2.Height = 30;
            //radioButton2.Size = new Size(20, 100);

            radioButton2.CheckedChanged +=
            new EventHandler(RadioButton_CheckedChanged);

            panel1.Controls.Add(radioButton2);
        }
        else if (e.Node.Text == "ListBox")
        {
            // Добавляем на панель список

            listBox1 = new ListBox();
            listBox1.Items.Add("Зеленый");
            listBox1.Items.Add("Желтый");
            listBox1.Items.Add("Голубой");
            listBox1.Items.Add("Серый");
            
            listBox1.Location = new Point(20, 250);
            listBox1.Width = 100; listBox1.Height = 100;
            listBox1.SelectedIndexChanged +=
            new EventHandler(listBox1_SelectedIndexChanged);

            panel1.Controls.Add(listBox1);
        }
        else if (e.Node.Text == "TextBox")
        {
            // Добавляем на панель текстовое поле

            TextBox textBox1 = new TextBox();
            textBox1.Multiline = true;
            textBox1.Text = "Это текстовое окно. Сюда можно вводить текст!" +
                "\r\n" + " Сотрите этот текст и введите свой!";
            textBox1.Location = new Point(180, 100);
            textBox1.Width = 400; textBox1.Height = 40;

            panel1.Controls.Add(textBox1);
        }
        else if (e.Node.Text == "DataGridView")
        {
            // Добавляем на панель таблицу, заполненную данными из файла xml

            DataSet dataSet1 = new DataSet("Пример DataSet");
            dataSet1.ReadXml("..//..//images//marks.xml");

            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.Width = 250;
            dataGridView1.Height = 150;
            dataGridView1.Location = new Point(20, 500);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataSet1;
            dataGridView1.DataMember = "предметы";
            //dataGridView1.DataMember = "оценка";

            //dataGridView1.ColumnCount = 2;
            panel1.Controls.Add(dataGridView1);

        }
        else if (e.Node.Text == "TabControl")
        {
            // Добавляем на панель элемент управления вкладками
            // и наполняем каждую вкладку содержимым

            TabControl tabControl1 = new TabControl();
            tabControl1.Location = new Point(190, 150);
            tabControl1.Size = new Size(300, 300);
           

            TabPage tabPage1 = new TabPage("Вадик");
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap("..//..//images//Vadik.jpg");

            pictureBox1.Size = new Size(300, 200);
            tabPage1.Controls.Add(pictureBox1);
            Label labelV = new Label();
            labelV.Top = 200;
            labelV.Size = new Size(300, 50);
            labelV.Text = "Это Вадик! Он любит купаться и работать на компьютере!";
            tabPage1.Controls.Add(labelV);
            tabControl1.TabPages.Add(tabPage1);

            TabPage tabPage2 = new TabPage("Его компьютер");
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap("..//..//images//comp.jpg");
            pictureBox2.Size = new Size(300, 200);
            tabPage2.Controls.Add(pictureBox2);
            Label labelС = new Label();
            labelС.Top = 200;
            labelС.Size = new Size(300, 50);
            labelС.Text = "Это компьютер Вадика! Пока Вадик купается, " +
                "он разрешает работать на компьютере ящерице!";
            tabPage2.Controls.Add(labelС);
            tabControl1.TabPages.Add(tabPage2);

            TabPage tabPage3 = new TabPage("Компьютерия");
            PictureBox pictureBox3 = new PictureBox();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = new Bitmap("..//..//images//terra.jpg");
            pictureBox3.Size = new Size(300, 200);
            tabPage3.Controls.Add(pictureBox3);
            Label labelT = new Label();
            labelT.Top = 200;
            labelT.Size = new Size(300, 50);
            labelT.Text = "Это страна Компьютерия!" +
                " Она расположена на берегу реки Тверца в Тверской области!";
            tabPage3.Controls.Add(labelT);
            tabControl1.TabPages.Add(tabPage3);
           
            panel1.Controls.Add(tabControl1);
        }
        else if (e.Node.Text == "PictureBox")
        {
            // Добавляем на панель изображение

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Image = new Bitmap("..//..//images//Zakat.jpg");
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(500, 250);
            pictureBox1.Size = new Size(250, 200);

            panel1.Controls.Add(pictureBox1);
        }
        else if (e.Node.Text == "RichTextBox")
        {
            // Добавляем поле для ввода текста с форматированием
            // Загружаем в него данные из файла XML

            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.LoadFile("..//..//images//marks.xml",
            RichTextBoxStreamType.UnicodePlainText);
            richTextBox1.WordWrap = false;
            richTextBox1.BorderStyle = BorderStyle.Fixed3D;
            richTextBox1.BackColor = Color.Beige;
            richTextBox1.Size = new Size(250, 150);
            richTextBox1.Location = new Point(300, 500);
           // panel1.Height - richTextBox1.Height - 5);

            panel1.Controls.Add(richTextBox1);
        }
        else if (e.Node.Text == "MainMenu")
        {
            // Добавляем классическое «меню» (появляется в верхней части окна)
            MainMenu mainMenu1 = new MainMenu();

            MenuItem menuItem1 = new MenuItem("File");
            menuItem1.MenuItems.Add("Exit",
            new EventHandler(mainMenu1_Exit_Select));
            mainMenu1.MenuItems.Add(menuItem1);

            MenuItem menuItem2 = new MenuItem("Background");
            menuItem2.MenuItems.Add("Choose",
            new EventHandler(mainMenu1_ColorOwn_Select));
            menuItem2.MenuItems.Add("White",
            new EventHandler(mainMenu1_ColorWhite_Select));
            mainMenu1.MenuItems.Add(menuItem2);

            this.Menu = mainMenu1;

            MessageBox.Show("Главное меню добавлено в окно " +
            "Испытайте его после нажатия OK.");

        }
        else if (e.Node.Text == "ToolBar")
        {
            // Добавляем на панель элемент "панель управления" с кнопками быстрого вызова

            ToolBar toolBar1 = new ToolBar();
            toolBar1.Size = new Size(100, 100);
            toolBar1.Dock = DockStyle.Right;
            ImageList imageList1 = new ImageList();
            imageList1.Images.Add(new Bitmap("../../images/new.gif"));
            imageList1.Images.Add(new Bitmap("../../images/open.gif"));
            imageList1.Images.Add(new Bitmap("../../images/copy.gif"));
            toolBar1.ImageList = imageList1;

            ToolBarButton toolBarbutton1 = new ToolBarButton("New");
            toolBarbutton1.ImageIndex = 0;
            toolBar1.Buttons.Add(toolBarbutton1);

            ToolBarButton toolBarbutton2 = new ToolBarButton("Open");
            toolBarbutton2.ImageIndex = 1;
            toolBar1.Buttons.Add(toolBarbutton2);

            ToolBarButton toolBarButton3 = new ToolBarButton("Copy");
            toolBarButton3.ImageIndex = 2;
            toolBar1.Buttons.Add(toolBarButton3);

            toolBar1.ButtonClick +=
            new ToolBarButtonClickEventHandler(toolBar1_Click);

            panel1.Controls.Add(toolBar1);
        }

    }

    /* Обработчики событий для добавленных выше элементов управления */

    // Обработчик события, срабатывающий при щелчке мышью на метке
    void label1_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show
        ("Да, у меток тоже есть событие Click. Но для них включение событий - редкость.");
    }

    // Обработчик события, срабатывающий при нажатии кнопки
    void button1_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show("Пора, наконец-то вы нажали меня!");
    }

    // Обработчик события, срабатывающий при установке или снятии флажка
    void CheckBox_CheckedChanged(object sender, System.EventArgs e)
    {
        if (checkBox1.Checked && checkBox2.Checked)
        {
            MessageBox.Show("У Вас все получится!");
        }
        else if (checkBox1.Checked)
        {
            MessageBox.Show("Не здорово быть умным и не скромным!");
        }
        else if (checkBox2.Checked)
        {
            MessageBox.Show("Скромность украшает. Хорошо бы еще быть умным!");
        }
        else
        {
            MessageBox.Show("Ни скромности, ни таланта?");
        }
    }

    // Обработчик события, срабатывающий при нажатии переключателя
    void RadioButton_CheckedChanged(object sender, System.EventArgs e)
    {
        if (radioButton1.Checked)
        {
            MessageBox.Show("Доброту все любят!");
        }
        else if (radioButton2.Checked)
        {
            MessageBox.Show("Это замечательно!");
        }
    }

    // Обработчик события, срабатывающий при выборе одного из пунктов списка
    void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        switch (listBox1.SelectedItem.ToString())
        {
            case ("Зеленый"): treeView1.BackColor = Color.Green; break;
            case ("Желтый"): treeView1.BackColor = Color.Yellow; break;
            case ("Голубой"): treeView1.BackColor = Color.Blue; break;
            case ("Серый"): treeView1.BackColor = Color.Gray; break;

        }
    }

    // Обработчик события, срабатывающий при выборе в меню пункта "White"
    void mainMenu1_ColorWhite_Select(object sender, System.EventArgs e)
    {
        treeView1.BackColor = Color.White;
    }

    // Обработчик события, срабатывающий при выборе в меню цвета
    void mainMenu1_ColorOwn_Select(object sender, System.EventArgs e)
    {
        ColorDialog colorDialog1 = new ColorDialog();
        colorDialog1.Color = treeView1.BackColor;
        colorDialog1.ShowDialog();
        treeView1.BackColor = colorDialog1.Color;
    }

    // Обработчик события, срабатывающий при выборе в меню пункта "exit"
    void mainMenu1_Exit_Select(object sender, System.EventArgs e)
    {
        if (
        MessageBox.Show("Вы уверены, что хотите закончить работу?",
        "Exit confirmation", MessageBoxButtons.YesNo)
        == DialogResult.Yes
       )
        {
            this.Dispose();
        }
    }

    // Обработчик события, срабатывающий при нажатии кнопки на панели инструментов
    void toolBar1_Click
    (object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
    {
        if (e.Button.Text == "Open")
        {
            MessageBox.Show("Здесь мог бы открываться файл!");
        }
        else if (e.Button.Text == "New")
        {
            MessageBox.Show("Здесь мог бы создаваться файл!");
        }
        else if (e.Button.Text == "Copy")
        {
            MessageBox.Show("Здесь мог бы копироваться файл!?");
        }
    }

    static void Main()
    {
        // // Создаем и запускаем форму
        Application.Run(new FormWithManyControls());
    }
}
