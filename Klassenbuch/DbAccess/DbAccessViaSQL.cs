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
        /*
        public enum Mode
        {
            Insert,
            Update,
            Delete
        }
        */


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

        //public static DataTable GetUntertichtInfo(string raumBezeichnung, string einheitBeginn, string unterrichtDatum)
        public static DataTable GetUntertichtInfo(long raumId, long einheitId, string unterrichtDatum)
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

                    "WHERE Datum = @unterrichtDatum  AND Einheit.ID = @EinheitID AND Raum.ID = @RaumID";

                    command.Parameters.AddWithValue("@RaumID", raumId);
                    command.Parameters.AddWithValue("@unterrichtDatum", unterrichtDatum);
                    command.Parameters.AddWithValue("@EinheitID", einheitId);

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
                    command.CommandText = "SELECT Raum.ID, Raum.Bezeichnung AS Raum FROM Raum";


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


        public static DataTable GetSchuelerVonKlasse(long klasseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    
                    command.CommandText =

                    "SELECT Schueler.ID " +
                    "FROM Schueler " +

                    "INNER JOIN Klasse " +
                    "ON Klasse.ID = Schueler.KlasseID " +

                    "WHERE Klasse.ID = @KlasseID";


                    command.Parameters.AddWithValue("@KlasseID", klasseId);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtSchuelerKlasse = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtSchuelerKlasse.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtSchuelerKlasse.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtSchuelerKlasse.Rows.Add(row);
                    }
                    reader.Close();
                    return dtSchuelerKlasse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetSchuelerVonKlasse(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
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
                   
                    command.CommandText = "SELECT Einheit.ID, FORMAT(Einheit.Beginn, N'hh\\:mm') + ' - ' + FORMAT(Einheit.Ende, N'hh\\:mm') AS [Zeit] FROM Einheit";

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






        public static DataTable GetKlassen()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;

                    command.CommandText = "SELECT Klasse.ID, Klasse.Bezeichnung FROM Klasse";

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtKlassen = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtKlassen.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtKlassen.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtKlassen.Rows.Add(row);
                    }
                    reader.Close();
                    return dtKlassen;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetKlassen(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }
        }





        public static DataTable GetPersonID(string vorname, string nachname)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                    "SELECT Person.ID FROM PERSON WHERE Person.Vorname = @Vorname AND Person.Nachname = @Nachname";

                    command.Parameters.AddWithValue("@Vorname", vorname);
                    command.Parameters.AddWithValue("@Nachname", nachname);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dtPersonID = new DataTable();


                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        dtPersonID.Columns.Add(reader.GetName(col), reader.GetFieldType(col));
                    }

                    while (reader.Read())
                    {
                        DataRow row = dtPersonID.NewRow();

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            row[col] = reader.GetValue(col);
                        }

                        dtPersonID.Rows.Add(row);

                    }
                    reader.Close();

                    return dtPersonID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetPersonID(): Fehler: {0} Grund: {1}", ex.GetType(), ex.Message);
                return null;
            }
        }










        public static DataTable GetUntaetigeKlassen(string datum, long einheitId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                    "SELECT " +
                    "Klasse.ID, " +
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

                    "WHERE Unterricht.Datum = @Datum AND Einheit.ID = @EinheitID " +
                    ") " +

                    "GROUP BY Klasse.ID, Klasse.Bezeichnung";


                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@EinheitID", einheitId);

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


        public static DataTable GetUntaetigeFaecher(string datum, long einheitId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandText =

                    "SELECT " +
                    "Fach.ID, " +
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

                    "WHERE Unterricht.Datum = @Datum AND Einheit.ID = @EinheitID " +
                    ") ";


                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@EinheitID", einheitId);

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
            string datum, long einheitId, long raumId, int locationX, int locationY, string lernstoff)
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
                    "Datum = @Datum  AND Einheit.ID = @EinheitID AND Raum.ID = @RaumID";

                    SqlCommand command = new SqlCommand(sqlUpdate, connection);

                    command.Parameters.AddWithValue("@Kommentar", kommentar);

                    object objAnwesend = DBNull.Value;
                    if (anwesend.HasValue)
                    {
                        objAnwesend = anwesend.Value;
                    }
                    command.Parameters.AddWithValue("@Anwesend", objAnwesend);
                    command.Parameters.AddWithValue("@Vorname", vorname);
                    command.Parameters.AddWithValue("@Nachname", nachname);
                    command.Parameters.AddWithValue("@RaumID", raumId);
                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@EinheitID", einheitId);
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


        public static bool InsertUnterricht(string datum, long einheitId, long fachId, long schuelerId , long raumId, int layoutX)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;

                    command.CommandText =

                    "INSERT INTO Unterricht(Datum, EinheitID, FachID, SchuelerID, RaumID, Lernstoff, Kommentar, Layout_X, Layout_Y) " +
                    "VALUES(@Datum, @EinheitID, @FachID, @SchuelerID, @RaumID, '', '', @Layout_X, 10)";

                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@EinheitID", einheitId);
                    command.Parameters.AddWithValue("@FachID", fachId);
                    command.Parameters.AddWithValue("@SchuelerID", schuelerId);
                    command.Parameters.AddWithValue("@RaumID", raumId);
                    command.Parameters.AddWithValue("@Layout_X", layoutX);

                    connection.Open();

                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "InsertUnterricht(): Fehler: {0} Grund: {1}",
                    ex.GetType(), ex.Message);
                return false;
            }
        }





        public static bool InsertPerson(string vorname, string nachname)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;

                    command.CommandText =

                    "INSERT INTO Person(Vorname, Nachname) " +
                    "VALUES(@Vorname, @Nachname)";

                    command.Parameters.AddWithValue("@Vorname", vorname);
                    command.Parameters.AddWithValue("@Nachname", nachname);

                    connection.Open();

                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "InsertPerson(): Fehler: {0} Grund: {1}",
                    ex.GetType(), ex.Message);
                return false;
            }
        }




        public static bool InsertSchueler(long personId, long klasseId)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(DbKlassenbuchConnectionString))
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;

                    command.CommandText =

                    "INSERT INTO Schueler(PersonID, KlasseID) " +
                    "VALUES(@PersonID, @KlasseID)";

                    command.Parameters.AddWithValue("@PersonID", personId);
                    command.Parameters.AddWithValue("@KlasseID", klasseId);

                    connection.Open();

                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "InsertSchueler(): Fehler: {0} Grund: {1}",
                    ex.GetType(), ex.Message);
                return false;
            }
        }



    }
}
