using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Klassenbuch.DbAccess
{
    class DbAccessViaSQL
    {
        public enum Mode
        {
            Insert,
            Update,
            Delete
        }



        public static string DbKlassenbuchConnectionString
        {
            get
            {

                // string windowsAuthSQLEXPRESS = "Data Source=.\\SQLEXPRESS;Initial Catalog=KLassenbuch;Integrated Security=true";
                //string windowsAuth = "Data Source=(local);Initial Catalog=KLassenbuch;Integrated Security=true";
                //sstring sqlServerAuth = "Data Source=(local);Initial Catalog=Alfatraining;UID=Alfa-SQL;PWD=alfa";



                //SqlConnectionStringBuilder csWindowsAuth = new SqlConnectionStringBuilder();

                //csWindowsAuth.DataSource = "(local)";
                //csWindowsAuth.InitialCatalog = "Klassenbuch";
                //csWindowsAuth.IntegratedSecurity = true;

                // string windowsAuth = csWindowsAuth.ConnectionString;

                // über App.Config datei, so muss man nicht neu kompilieren,
                // wenn sich mal der datenbank name ändert oder so
                string windowsAuth = Properties.Settings.Default.DbConnectionString;


                string connectionString = windowsAuth;
                return connectionString;

            }
        }


        public static DataTable GetUntertichtInfo(int raumId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                   // keine Zeilenumbrüche und deswegen Fehler durch die Kommentare?????
                    "SELECT " +
                    "Unterricht.Datum, " +
                    "Einheit.Beginn, " +
                    "Einheit.Ende, " +
                    "Fach.Bezeichnung AS [Fach], " +
                    "Raum.Bezeichnung AS [Raum], " +
                    "Lehrer.ID AS [Lehrer ID], " +
                    "Klasse.Bezeichnung AS [Klasse], " +
                    "Person.Vorname, " +
                    "Person.Nachname, " +
                    "Schueler.Layout_X, " +
                    "Schueler.Layout_Y " +

                    "FROM Unterricht " +

                    "INNER JOIN Raum " +
                    "ON Unterricht.RaumID = Raum.ID " +

                    "INNER JOIN Fach " +
                    "ON Unterricht.FachID = Fach.ID " +

                    "INNER JOIN Lehrer " +
                    "ON Fach.LehrerID = Lehrer.ID " +

                    "INNER JOIN Schueler " +
                    "ON Unterricht.SchuelerID = Schueler.ID " +

                    "INNER JOIN Person " +
                    "ON Schueler.PersonID = Person.ID " +

                    "INNER JOIN Einheit " +
                    "ON Unterricht.EinheitID = Einheit.ID " +

                    "INNER JOIN Klasse " +
                    "ON Schueler.KlasseID = Klasse.ID " +


                    "WHERE Datum = '2019-10-01'  AND EinheitID = 1 AND RaumID = @raumId";
                

                    //"SELECT Nachname, Vorname FROM Person WHERE ID = 2";





                    SqlParameter pRaumId = new SqlParameter("@raumId", SqlDbType.BigInt);
                    pRaumId.Value = raumId;

                    command.Parameters.Add(pRaumId);


                    connection.Open();
                    Debug.WriteLine("DB OPEND ...");

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtUnterrichtInfo = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtUnterrichtInfo.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while(reader.Read())
                    {
                        DataRow row = dtUnterrichtInfo.NewRow();

                        for(int col=0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtUnterrichtInfo.Rows.Add(row);

                    }


                    reader.Close();
                    Debug.WriteLine("DB CLOSED ...");
                    return dtUnterrichtInfo;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("GetKurse(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }

        }











        public static DataTable GetRaeume()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =


                    "SELECT " +
                    "Unterricht.Datum, " +
                    "Einheit.Beginn, " +
                    "Einheit.Ende, " +
                    "Fach.Bezeichnung AS [Fach], " +
                    "Raum.Bezeichnung AS [Raum], " +
                    "Lehrer.ID AS [Lehrer ID], " +
                    "Klasse.Bezeichnung AS [Klasse], " +
                    "Person.Vorname, " +
                    "Person.Nachname, " +
                    "Schueler.Layout_X, " +
                    "Schueler.Layout_Y " +

                    "FROM Unterricht " +

                    "INNER JOIN Raum " +
                    "ON Unterricht.RaumID = Raum.ID " +

                    "INNER JOIN Fach " +
                    "ON Unterricht.FachID = Fach.ID " +

                    "INNER JOIN Lehrer " +
                    "ON Fach.LehrerID = Lehrer.ID " +

                    "INNER JOIN Schueler " +
                    "ON Unterricht.SchuelerID = Schueler.ID " +

                    "INNER JOIN Person " +
                    "ON Schueler.PersonID = Person.ID " +

                    "INNER JOIN Einheit " +
                    "ON Unterricht.EinheitID = Einheit.ID " +

                    "INNER JOIN Klasse " +
                    "ON Schueler.KlasseID = Klasse.ID " +


                    "WHERE Datum = '2019-10-01'  AND EinheitID = 1 AND RaumID = @raumId";



                    connection.Open();
                    Debug.WriteLine("DB OPEND ...");

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtUnterrichtInfo = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtUnterrichtInfo.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtUnterrichtInfo.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtUnterrichtInfo.Rows.Add(row);

                    }


                    reader.Close();
                    Debug.WriteLine("DB CLOSED ...");
                    return dtUnterrichtInfo;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetKurse(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }

        }
























    }
}
