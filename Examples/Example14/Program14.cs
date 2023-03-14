using System;
using System.Windows.Forms;
using System.Data;
// Пространство имен для работы с базами данных SQL Server
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
class DataInOutGrid : Form
{
    SqlDataAdapter dataAdapter;
    DataGridView dataGridView;

    public DataInOutGrid()
    {
        //Изменяем размеры формы
        this.Width = 450;
        this.Height = 400;

        // Указываем заголовок окна
        this.Text = "Двустороннее связывание:" +
            " база данных и элемент Grid.";
        // Добавляем элементы управления - 
        //метку, таблицу и командную кнопку
        Label labelCaption = new Label();
        labelCaption.Text = "Планеты!";
        labelCaption.Location = new Point(60, 10);
        labelCaption.Width = 200;
        labelCaption.Parent = this;

        // Добавляем элемент DataGridView на форму

        dataGridView = new DataGridView();
        dataGridView.Width = 350;
        dataGridView.Height = 250;
        dataGridView.Location = new Point(20, 50);
        dataGridView.AutoResizeColumns();
        this.Controls.Add(dataGridView);

        // Добавляем командную кнопку
        Button buttonSave = new Button();
        buttonSave.Location = new Point(100, 320);
        buttonSave.Width = 220;
        buttonSave.Text = "Сохранить изменения в базе данных!";
        buttonSave.Click += 
            new System.EventHandler(ButtonSave_Click);
        buttonSave.Parent = this;

        // Формируем запрос к базе данных - 
        //запрашиваем информацию о планетах
        string sql = "SELECT * FROM PLANET";
        string connectionString;
        // DataTable сохраняет данные в памяти как таблицу
        DataTable dataTable = new DataTable();
        /*
        //Вариант 1
        // Подключаемся к базе данных SQL Server Express Edition
        
        // Указываем физический путь к базе данных PLANETS
        string dbLocation = 
        ("../../../databases/planets.mdf");

        connectionString = @"data source=.\SQLEXPRESS;" +
              "User Instance=true;Integrated Security=SSPI;" +
          "AttachDBFilename=" + dbLocation;
        SqlConnection connection = new SqlConnection(connectionString);
       */

        //Вариант 2
        // Подключаемся к базе данных SQL Server 2005
        connectionString =
            "data source = localhost; Initial Catalog = Planets;" +
             "Integrated Security = SSPI";
        SqlConnection connection = new SqlConnection(connectionString);

        //Открываем соединение
        connection.Open();

        //Создаем команду 
        SqlCommand sqlCommand = new SqlCommand(sql, connection);
        //Создаем адаптер
        // DataAdapter - посредник между базой данных и DataSet
        dataAdapter = new SqlDataAdapter(sqlCommand);

        //Создаем построитель команд
        //Для адаптера становится доступной команда Update 
        SqlCommandBuilder commandBuilder =
            new SqlCommandBuilder(dataAdapter);
        
        // Данные из адаптера поступают в DataTable 
        dataAdapter.Fill(dataTable);
        // Связываем данные с элементом DataGridView
        dataGridView.DataSource = dataTable;
        // Очистка
        connection.Close();
    }   

       
    static void Main()
    {
        // Создаем и запускаем форму 
        Application.Run(new DataInOutGrid());
    }
    
    void ButtonSave_Click(object sender, System.EventArgs args)
    {
        try
        {
            dataAdapter.Update((DataTable)dataGridView.DataSource);
            MessageBox.Show("Изменения в базе данных выполнены!",
                "Уведомление о результатах", MessageBoxButtons.OK);
        }
        catch(Exception)
        {
            MessageBox.Show("Изменения в базе данных выполнить не удалось!",
                            "Уведомление о результатах", MessageBoxButtons.OK);
        }
    }
} 

