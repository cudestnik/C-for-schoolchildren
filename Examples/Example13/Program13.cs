using System.Windows.Forms;
using System.Data;
// Пространство имен для работы с базами данных SQL Server
using System.Data.SqlClient;
using System.Drawing;
// Пространство имен для работы с базами данных Access
using System.Data.OleDb;
class DataInGrid : Form
{
    public DataInGrid()
    {
        //Изменяем размеры формы
        this.Width = 450;
        this.Height = 400;

        // Указываем заголовок окна
        this.Text = "Одностороннее связывание:" +
            " база данных и элемент Grid.";
        // Добавляем элементы управления - метку и таблицу
        Label labelCaption = new Label();
        labelCaption.Text = "Планеты солнечной системы!";
        labelCaption.Location = new Point(60, 10);
        labelCaption.Width = 200;
        labelCaption.Parent = this;

        // Добавляем элемент DataGridView на форму

        DataGridView dataGridView1 = new DataGridView();
        dataGridView1.Width = 350;
        dataGridView1.Height = 250;
        dataGridView1.Location = new Point(20, 50);
        dataGridView1.DataMember = "Table";
        dataGridView1.AutoResizeColumns();
        this.Controls.Add(dataGridView1);


        // Формируем запрос к базе данных - 
        //запрашиваем информацию о планетах
        string sql = "SELECT * FROM PLANET";
        string connectionString;
        // DataSet сохраняет данные в памяти
        //данные хранятся в виде таблиц данных DataTable
        DataSet dataSet1 = new DataSet();

        /*
        //Вариант 1
        // Подключаемся к базе данных SQL Server Express Edition
        
        // Указываем физический путь к базе данных PLANETS
        string dbLocation = 
        ("../../../databases/planets.mdf");

        connectionString = @"data source=.\SQLEXPRESS;" +
              "User Instance=true;Integrated Security=SSPI;" +
          "AttachDBFilename=" + dbLocation;
        SqlConnection connection1 = new SqlConnection(connectionString);
       */
        /*
        //Вариант 2
        // Подключаемся к базе данных SQL Server 2005
        connectionString =
            "data source = localhost; Initial Catalog = Planets;" +
             "Integrated Security = SSPI";
        SqlConnection connection1 = new SqlConnection(connectionString);

        //Открываем соединение
        connection1.Open();
    
        // DataAdapter - посредник между базой данных и DataSet
        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();

        // Создаем объект DataAdapter,
        //передаем ему данные запроса 
        sqlDataAdapter1.SelectCommand =
        new SqlCommand(sql, connection1);

        // Данные из адаптера поступают в DataSet 
        sqlDataAdapter1.Fill(dataSet1);

        // Связываем данные с элементом DataGridView 
        DataGridView1.DataSource = dataSet1;

        // Очистка
        connection1.Close();
         * */

        /*
        //Вариант 3. Связывание с базой данных Access 2003 - *.mdb
        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source= ../../../databases/planets.mdb";
        
        */
        //Вариант 4. Связывание с базой данных Access 2007 - *.accdb
        connectionString = "Provider=Microsoft.Ace.OLEDB.12.0;" +
            @"Data Source= ../../../databases/planets.accdb";


        OleDbConnection connection = new OleDbConnection(connectionString);
        connection.Open();

        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        dataAdapter.SelectCommand = new OleDbCommand(sql, connection);

        dataAdapter.Fill(dataSet1);
        dataGridView1.DataSource = dataSet1;

        // Очистка
        connection.Close();
    }

    static void Main()
    {
        // Создаем и запускаем форму 
        Application.Run(new DataInGrid());
    }
}
