using Livraria.Infra.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {

        public SqlConnection SqlServerConexao { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                SqlServerConexao = new SqlConnection(appSettings.ConnectionString);
                SqlServerConexao.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if(SqlServerConexao.State != System.Data.ConnectionState.Closed)
                SqlServerConexao.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
