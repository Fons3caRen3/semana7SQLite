using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace semana7
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();

    }
}
