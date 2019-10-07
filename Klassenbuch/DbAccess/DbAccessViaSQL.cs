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
                // über App.Config datei, so muss man nicht neu kompilieren,
                // wenn sich mal der datenbank name ändert oder so
                string connectionString = Properties.Settings.Default.DbConnectionString;
                return connectionString;

            }
        }

        public static DataTable GetUntertichtInfo(string raumBezeichnung, string einheitBeginn, string unterrichtDatum)
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
                    //"Lehrer.ID AS [Lehrer ID], " +
                    "(SELECT Person.Nachname + ', ' + Person.Vorname FROM Person WHERE Lehrer.ID = Person.ID) AS Lehrer," +
                    "Klasse.Bezeichnung AS [Klasse], " +
                    "Person.Vorname, " +
                    "Person.Nachname, " +
                    "Unterricht.Layout_X, " +
                    "Unterricht.Layout_Y, " +
                    "Unterricht.Kommentar, " +
                    "Unterricht.Anwesend, " +
                    "Unterricht.Lernstoff " +

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

                    // "WHERE Datum = '2019-10-01'  AND Einheit.Beginn = '08:00:00' AND Raum.Bezeichnung = @raumBezeichnung";
                    //"WHERE Datum = '2019-10-01'  AND Einheit.Beginn = @einheitBeginn AND Raum.Bezeichnung = @raumBezeichnung";
                    "WHERE Datum = @unterrichtDatum  AND Einheit.Beginn = @einheitBeginn AND Raum.Bezeichnung = @raumBezeichnung";

                    SqlParameter pRaumBezeichnung = new SqlParameter("@raumBezeichnung", SqlDbType.VarChar);
                    pRaumBezeichnung.Value = raumBezeichnung;

                    SqlParameter pEinheitBeginn = new SqlParameter("@einheitBeginn", SqlDbType.Time);
                    pEinheitBeginn.Value = einheitBeginn;

                    SqlParameter pUnterrichtDatum = new SqlParameter("@unterrichtDatum", SqlDbType.Date);
                    pUnterrichtDatum.Value = unterrichtDatum;

                    command.Parameters.Add(pRaumBezeichnung);
                    command.Parameters.Add(pEinheitBeginn);
                    command.Parameters.Add(pUnterrichtDatum);

                    connection.Open();
               
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

                    return dtUnterrichtInfo;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("GetUntertichtInfo(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
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
                    command.CommandText = "SELECT Raum.Bezeichnung AS Raum FROM Raum";


                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtRaumInfo = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtRaumInfo.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtRaumInfo.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtRaumInfo.Rows.Add(row);
                    }
                    reader.Close();
                    return dtRaumInfo;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetRaeume(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }
        }


        public static DataTable GetEinheiten()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText = "SELECT Einheit.Beginn, Einheit.Ende FROM Einheit";

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtEinheitInfo = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtEinheitInfo.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtEinheitInfo.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtEinheitInfo.Rows.Add(row);
                    }
                    reader.Close();
                    return dtEinheitInfo;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetEinheiten(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }
        }





        public static DataTable GetUntaetigeKlassen(string datum, string beginn)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                    "SELECT " +
                    "Klasse.Bezeichnung " +
                    "FROM Klasse " +
                    "WHERE Klasse.Bezeichnung NOT IN( " +

                    "SELECT " +
                    "Klasse.Bezeichnung " +
                    "FROM Klasse " +

                    "INNER JOIN Schueler " +
                    "ON Schueler.KlasseID = Klasse.ID " +

                    "INNER JOIN Unterricht " +
                    "ON  Unterricht.SchuelerID = Schueler.ID " +

                    "INNER JOIN Einheit " +
                    "ON Einheit.ID = Unterricht.EinheitID " +

                    "WHERE Unterricht.Datum = @Datum AND Einheit.Beginn = @Beginn " +
                    ") " +

                    "GROUP BY Klasse.Bezeichnung";


                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Beginn", beginn);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtUntaetigeKlassen = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtUntaetigeKlassen.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtUntaetigeKlassen.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtUntaetigeKlassen.Rows.Add(row);

                    }
                    reader.Close();

                    return dtUntaetigeKlassen;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetUntertichtInfo(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }

        }






        public static DataTable GetUntaetigeFaecher(string datum, string beginn)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                    "SELECT " +
                    "Fach.Bezeichnung " +
                    "FROM Fach " +
                    "WHERE Fach.Bezeichnung NOT IN( " +

                    "SELECT " +
                    "Fach.Bezeichnung " +
                    "FROM Fach " +

                    "INNER JOIN Unterricht " +
                    "ON  Unterricht.FachID = Fach.ID " +

                    "INNER JOIN Einheit " +
                    "ON Einheit.ID = Unterricht.EinheitID " +

                    "WHERE Unterricht.Datum = @Datum AND Einheit.Beginn = @Beginn " +
                    ") ";


                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Beginn", beginn);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtUntaetigeFaecher = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtUntaetigeFaecher.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtUntaetigeFaecher.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtUntaetigeFaecher.Rows.Add(row);

                    }
                    reader.Close();

                    return dtUntaetigeFaecher;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetUntaetigeFaecher(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }

        }







        public static bool UpdateUnterricht(string kommentar, bool? anwesend, string vorname, string nachname,
            string datum, string beginn, string raum, int locationX, int locationY, string lernstoff)
        {
            try
            {

                using (SqlConnection connection =
                    new SqlConnection(DbKlassenbuchConnectionString))
                {
                    string sqlUpdate =
                    "UPDATE Unterricht " +
                    "SET Kommentar = @Kommentar, Anwesend = @Anwesend, Layout_X = @Layout_X, Layout_Y = @Layout_Y, Lernstoff = @Lernstoff " +

                    "FROM Unterricht " +

                    "INNER JOIN Schueler " +
                    "ON Schueler.ID = Unterricht.SchuelerID " +

                    "INNER JOIN Person " +
                    "ON Person.ID = Schueler.PersonID " +

                    "INNER JOIN Raum " +
                    "ON Unterricht.RaumID = Raum.ID " +

                    "INNER JOIN Einheit " +
                    "ON Unterricht.EinheitID = Einheit.ID " +

                    "WHERE Person.Vorname = @vorname AND Person.Nachname = @nachname AND " +
                    "Datum = @Datum  AND Einheit.Beginn = @Beginn AND Raum.Bezeichnung = @Raum";

                    SqlCommand command = new SqlCommand(sqlUpdate, connection);

                    command.Parameters.AddWithValue("@Kommentar", kommentar);

                    object objAnwesend = DBNull.Value;
                    if (anwesend.HasValue)
                    {
                        objAnwesend = anwesend.Value;
                    }
                    command.Parameters.AddWithValue("@Anwesend", objAnwesend);
                   // command.Parameters.AddWithValue("@Anwesend", null);

                    command.Parameters.AddWithValue("@Vorname", vorname);
                    command.Parameters.AddWithValue("@Nachname", nachname);
                    command.Parameters.AddWithValue("@Raum", raum);

                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Beginn", beginn);

                    command.Parameters.AddWithValue("@Layout_X", locationX);
                    command.Parameters.AddWithValue("@Layout_Y", locationY);

                    command.Parameters.AddWithValue("@Lernstoff", lernstoff);

                    connection.Open();



                    return command.ExecuteNonQuery() == 1;
                }





              

            }
            catch(Exception ex)
            {
                Debug.WriteLine("UpdateUnterricht(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return false;

            }


        }























    }
}
