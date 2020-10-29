using MySql.Data.MySqlClient;

namespace ReportDBmySQL
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection(
            "Server = localhost; " +
            "Port = 3306; " +
            "Username = root; " +
            "Password = root; " +
            "database = reportdbmysqlhomes"
            );

1 таблица
Город
Улица
Дом

2 таблица Реестр
Город
Улица
Дом
Данные по счетчикам

3 таблица 2гис данные
Город
Улица
Дом
Данные по домам

4 таблица аскуэ
Город
Улица
Дом
Данные по подъездам
    }
}
