using System.Windows.Forms;
using System.Data;
// Пространство имен для работы с базами данных SQL Server
using System.Data.SqlClient;
using System.Drawing;
// Пространство имен для работы с базами данных Access
using System.Data.OleDb;
class SimpleDataAccess : Form
{
    public SimpleDataAccess()
    {
        // Указываем заголовок окна
        this.Text = "Работа с базой данных. Чтение данных.";
        // Добавляем элементы управления - метку и список
        Label labelCaption = new Label();
        labelCaption.Text = "Планеты солнечной системы!";
        labelCaption.Location = new Point(30, 10);
        labelCaption.Width = 200;
        labelCaption.Parent = this;

        ListBox listPlanets = new ListBox();
        listPlanets.Location = new Point(30, 50);
        listPlanets.Width = 100;
        listPlanets.Parent = this;

        // Формируем запрос к базе данных - 
        //запрашиваем информацию о планетах
        string sql = "SELECT * FROM PLANET";
        string connectionString;

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
        
        //Вариант 2
        // Подключаемся к базе данных SQL Server 2005
        connectionString =
            "data source = localhost; Initial Catalog = Planets;" +
             "Integrated Security = SSPI";
        SqlConnection connection1 = new SqlConnection(connectionString);
        
        //Открываем соединение
        connection1.Open();         
       
        SqlCommand command1 = new SqlCommand(sql, connection1);
        SqlDataReader dataReader1 = command1.ExecuteReader();
        // Организуем циклический перебор полученных записей
        //и выводим название каждой планеты в список
        while (dataReader1.Read())
        {
            listPlanets.Items.Add(dataReader1["PlanetName"]);
        }

        // Очистка
        dataReader1.Close();
        connection1.Close();
        /*
        
        //Вариант 3. Связывание с базой данных Access 2003 - *.mdb
        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source= ../../../databases/planets.mdb";
        

        //Вариант 4. Связывание с базой данных Access 2007 - *.accdb
        connectionString = "Provider=Microsoft.Ace.OLEDB.12.0;" +
            @"Data Source= ../../../databases/planets.accdb";


        OleDbConnection connection = new OleDbConnection(connectionString);
        connection.Open();
        OleDbCommand command = new OleDbCommand(sql, connection);
        OleDbDataReader dataReader = command.ExecuteReader();

        // Организуем циклический перебор полученных записей
        //и выводим название каждой планеты в список
        while (dataReader.Read())
        {
            listPlanets.Items.Add(dataReader["PlanetName"]);
        }

        // Очистка
        dataReader.Close();
        connection.Close();
         * */
    }

    static void Main()
    {
        // Создаем и запускаем форму 
        Application.Run(new SimpleDataAccess());
    }
}
