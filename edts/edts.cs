using Microsoft.Data.Sqlite;

public class Edts
{
    readonly static string dbPath = "en.db";
    readonly static string dbLink = $"Data Source={dbPath}";
    public int _userID = 0;

    //constructor 
    public Edts()
    {
        CreateTmpProfile(-1);
    }
    public Edts(int userID)
    {
        CreateTmpProfile(userID);
    }
    private void CreateTmpProfile(int userID)
    {
        DbOlustur();
        _userID = userID;
    }

    //STATIC
    public static void DbOlustur()
    {
        try
        {

            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            var createCmd = connection.CreateCommand();
            createCmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserName TEXT NOT NULL,
                FullName Text,
                psw TEXT,
                DateOfBirth INTEGER,
                AccessLevel INTEGER,
                Title Text
            );
        ";
            createCmd.ExecuteNonQuery();

            createCmd = connection.CreateCommand();
            createCmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Categories (
                ID        INTEGER PRIMARY KEY AUTOINCREMENT,
                CategoryCode      TEXT UNIQUE NOT NULL,
                CategoryName      TEXT NOT NULL,
                Description       TEXT,
                ParentCategoryID  INTEGER,
                IsActive          BOOLEAN DEFAULT 1
            );
        ";
            createCmd.ExecuteNonQuery();

            createCmd = connection.CreateCommand();
            createCmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Products (
                ProductID      INTEGER PRIMARY KEY AUTOINCREMENT,
                ProductCode    TEXT UNIQUE NOT NULL,
                ProductName    TEXT NOT NULL,
                CategoryID     INTEGER NOT NULL,
                Description    TEXT,
                Quantity       INTEGER DEFAULT 0,
                UnitPrice      DECIMAL(10,2)
            );
        ";
            createCmd.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            Clipboard.SetText(e.ToString());
            MessageBox.Show(e.ToString());
        }
    }

    public static int UserGetAccessValue(int userID)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT accessLevel FROM Users WHERE Id = $id LIMIT 1;";
            cmd.Parameters.AddWithValue("$id", userID);

            var fnl = cmd.ExecuteScalar();
            if (fnl == null || fnl == DBNull.Value)
                return -1;
            return Convert.ToInt32(fnl);
        }
        catch (Exception)
        {

        }
        return -1;
    }

    public static bool GetPermission(int accessValue, UserAccess permission)
    {
        return ((UserAccess)accessValue & permission) != 0;
    }
    public static int SetPermission(int accessValue, UserAccess permission, bool newState)
    {
        if (newState)
            accessValue |= (int)permission;
        else
            accessValue &= ~(int)permission;
        return accessValue;
    }

    public static void UserChangePsw(int userID, string newPsw)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Users SET psw = $newPsw WHERE id=$userID";
            cmd.Parameters.AddWithValue("$newPsw", newPsw);
            cmd.Parameters.AddWithValue("$userID", userID);

            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

        }
    }
    public static int GetUserId(string userName)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id FROM Users WHERE UserName = $name LIMIT 1;";
            cmd.Parameters.AddWithValue("$name", userName);

            var fnl = cmd.ExecuteScalar();
            if (fnl == null || fnl == DBNull.Value)
                return -1;
            return Convert.ToInt32(fnl);
        }
        catch (Exception)
        {

        }
        return -2;
    }

    public static bool UserLogin(string userName, string psw)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT psw FROM Users WHERE UserName = $name LIMIT 1;";
            cmd.Parameters.AddWithValue("$name", userName);

            var tmp = cmd.ExecuteScalar();

            if (tmp == null || tmp == DBNull.Value)
                return false;
            return tmp.ToString() == psw;
        }
        catch (Exception en)
        {

            Clipboard.SetText(en.ToString());
            MessageBox.Show(en.ToString());

        }
        return false;
    }

    // USER PERMISSION
    public bool PermissionCheck(UserAccess permission)
    {
        if (_userID != -1)
        {
            return GetPermission(UserGetAccessValue(_userID), permission);
        }
        else
        {
            return true;
        }
    }

    public void AddCategory(string CategoryCode, string CategoryName, string Description, int ParentCategoryID)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO Categories (CategoryCode, CategoryName, Description, ParentCategoryID)
        VALUES (@CategoryCode, @CategoryName, @Description, @ParentCategoryID);
    ";

            cmd.Parameters.AddWithValue("@CategoryCode", CategoryCode);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@ParentCategoryID", ParentCategoryID);
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

        }
    }

    public void AddProduct(string ProductCode, string ProductName, int CategoryID, string Description)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO Products (ProductCode, ProductName, Description, CategoryID)
        VALUES (@CategoryCode, @CategoryName, @Description, @CategoryID);
    ";

            cmd.Parameters.AddWithValue("@ProductCode", ProductCode);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

        }
    }

    public void AddUser(string userName, string psw, string fullName, int accessLevel, string title)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO Users (UserName, psw, FullName, AccessLevel, Title)
        VALUES (@userName, @psw, @fullName, @accessLevel, @title);
    ";

            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@psw", psw);
            cmd.Parameters.AddWithValue("@fullName", fullName);
            cmd.Parameters.AddWithValue("@accessLevel", accessLevel);
            cmd.Parameters.AddWithValue("@title", title);

            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

        }
    }

    public void UserSetAccessValue(int userID, int newValue)
    {
        try
        {
            using var connection = new SqliteConnection(dbLink);
            connection.Open();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Users SET AccessLevel = $AccessLevel WHERE id=$id";
            cmd.Parameters.AddWithValue("$AccessLevel", newValue);
            cmd.Parameters.AddWithValue("$id", userID);

            cmd.ExecuteNonQuery();
        }
        catch (System.Exception)
        {

        }
    }

}

[Flags]
public enum UserAccess
{
    None = 0,        // 0000
    ProductsEdit = 1 << 0,   // 0001
    CategoriesEdit = 1 << 1,   // 0010
    UsersEdit = 1 << 2,   // 0100
    Admin = 1 << 3    // 1000
}
