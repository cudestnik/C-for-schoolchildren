using System;
using System.Windows.Forms;
using System.Drawing;
// Пространство имен для работы XML-данными
using System.Xml;
//Пространство имен для работы с выражениями xPath
using System.Xml.XPath;
class XmlRetriever: Form
{
    ComboBox comboBox1;
    Button button1;
    ListBox listBox1;
    RichTextBox richTextBox1;
    XmlDocument xmlDoc;

    // Метод-конструктор нашего класса
    public XmlRetriever()
    {
        // Задаем заголовок и размеры окна
        this.Text = "Работа с XML документом";                
        this.Size = new Size(400, 400);

        // Создаем объект XmlDocument, используя xml файл
        xmlDoc = new XmlDocument();      
        xmlDoc.Load("../../docs/Planets.xml");

        // Создаем объект TextBox для вывода данных
        richTextBox1 = new RichTextBox();
        richTextBox1.Dock = DockStyle.Top;
        richTextBox1.AcceptsTab = true;
        richTextBox1.Height = 180;
        richTextBox1.ReadOnly = true;
        richTextBox1.BackColor = Color.Silver;

        // Помещаем XML-данные в элемент TextBox
        richTextBox1.Text = xmlDoc.OuterXml;
        this.Controls.Add(richTextBox1);

        // Создаем объект ComboBox
        // В элементы списка этого объекта записываем
        //различные выражения XPath, 
        //позволяющие искать нужные элементы XML документа 
        comboBox1 = new ComboBox();
        comboBox1.Location = new Point(0, 200);
        comboBox1.Width = 300;
        comboBox1.Items.Add("/Планета");
        comboBox1.Items.Add("/Планета/Континент");
        comboBox1.Items.Add("/Планета/Континент/Страна");
        comboBox1.Items.Add(
            "/Планета/Континент/Страна[@столица='Рио-де-Жанейро']");
        comboBox1.SelectedIndex = 0;
        this.Controls.Add(comboBox1);

        // Создаем командную кнопку для поиска и отображения
        // соответствующих элементов Xml документа
        button1 = new Button();
        button1.Text = "Получить данные";
        button1.Location = new Point(100, 230);
        button1.Width = 150;
        button1.Height = 40;
        button1.Click += new EventHandler(Button1_Click);
        this.Controls.Add(button1);

        // Создаем элемент ListBox для отображения элементов
        listBox1 = new ListBox();
        listBox1.Dock = DockStyle.Bottom;
        listBox1.Location = new Point(10, 10);
        this.Controls.Add(listBox1);
    }

    static void Main()
    {
        // Создаем и запускаем новый экземпляр класса
        Application.Run(new XmlRetriever());
    }

    // Обработчик события, срабатывающий при нажатии кнопки
    void Button1_Click(object sender, EventArgs e)
    {
        XmlNodeList xmlNodes;
        XmlNode xmlElement;
        string elementValue;

        // Используем охраняемый блок try-catch,
        // что позволит в случае ошибок  в выражениях XPath
        // перехватывать обработку исключений,выдавать сообщение
        // об ошибке и нормально продолжить работу приложения
        try
        {
            // Выбираем из XML-документа элементы, соответствующие
            // выражению XPath, заданному выбранным элементом ComboBox
            xmlNodes = xmlDoc.SelectNodes(comboBox1.Text);            

            // Производим циклический перебор найденных элементов,
            // добавляя каждый элемент в ListBox
            listBox1.Items.Clear();
            for (int i = 0; i < xmlNodes.Count; i++)
            {
                xmlElement = xmlNodes[i];
                if (xmlElement.HasChildNodes)
                {
                    elementValue = xmlElement.FirstChild.Value.Trim();
                    listBox1.Items.Add(elementValue);
                }
            }
        }
        catch (XPathException ex)
        {
            const string errorMessage =
                "Ошибка в задании выражения XPath!" +
                "\r\n" + "Соответствующие данные в документе не найдены!" +
                "\r\n" + "Попробуйте задать другое выражение!";
            MessageBox.Show(errorMessage +"\r\n" + ex.Message);            
        }
    }
}

