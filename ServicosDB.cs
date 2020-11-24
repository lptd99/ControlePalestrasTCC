using System;
using System.Data.SqlClient;

namespace TCCADS
{
    public class ServicosDB : IDisposable
    {
        public const string SERVIDOR = @"DESKTOP_PCH001\TCCADS01";
        public const string BANCO = "TCCADS";
        public const string USUARIO = "sa";
        public const string SENHA = "admin00";

        public SqlConnection Conexao { get; private set; }

        public ServicosDB()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = SERVIDOR,
                InitialCatalog = BANCO,
                UserID = USUARIO,
                Password = SENHA
            };

            Conexao = new SqlConnection(sb.ToString());
            Conexao.Open();
        }

        public SqlCommand CriarCommand(string Sql, params SqlParameter[] ParametroBD)
        {
            SqlCommand cmd = new SqlCommand(Sql, Conexao);

            if ((ParametroBD != null) && (ParametroBD.Length > 0))
            {
                foreach (var p in ParametroBD)
                {
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        public SqlDataReader ExecQuery(string Sql, params SqlParameter[] ParametroBD)
        {
            return CriarCommand(Sql, ParametroBD).ExecuteReader();
        }

        public int ExecUpdate(string Sql, params SqlParameter[] ParametroBD)
        {
            return CriarCommand(Sql, ParametroBD).ExecuteNonQuery();
        }

        public object QueryValue(string Sql, params SqlParameter[] ParametroBD)
        {
            return CriarCommand(Sql, ParametroBD).ExecuteScalar();
        }

        public void Dispose()
        {
            Conexao.Close();
            Conexao.Dispose();
        }

        public static SqlConnection createSQLServerConnection(string server, string database, string user, string senha)
        {
            SqlConnectionStringBuilder sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder.DataSource = server;                       // SERVIDOR
            sqlStringBuilder.InitialCatalog = database;                 // BANCO
            sqlStringBuilder.UserID = user;                             // USER
            sqlStringBuilder.Password = senha;                          // SENHA

            SqlConnection sqlConnection = new SqlConnection(sqlStringBuilder.ToString());
            sqlConnection.Open();                                       // ABRIR CONEXÃO
            return sqlConnection;
        }

        public static SqlDataReader createSQLCommandReader(SqlConnection connection, string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);    // EXECUTAR COMANDO
            return sqlCommand.ExecuteReader();                              // PERMITIR LEITURA
        }
    }
}