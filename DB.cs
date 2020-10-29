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

0 таблица
Id
Город

1 таблица
IdГород
Улица
Дом

2 таблица Реестр
IdУлица
IdДом
Данные по счетчикам

3 таблица 2гис данные
IdУлица
IdДом
Данные по домам

4 таблица аскуэ
IdУлица
IdДом
Данные по подъездам
    }
}
