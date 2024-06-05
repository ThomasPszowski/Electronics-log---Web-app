
using projekt_web.Models;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SQLite;

namespace projekt_web
{
    public class SQLiteItemRepository : IItemRepository
    {
        string DatabaseFilePath { get; set; }
        
        public SQLiteItemRepository()
        {
            DatabaseFilePath = "wwwroot/Databases/Items.db";
        }
        public SQLiteItemRepository(string databaseFilePath)
        {
            DatabaseFilePath = databaseFilePath;
        }

        public int Create(Item item)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Items WHERE Name = @Name";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Name", item.Name);

                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        return -1; 
                    }
                }
                string query = "INSERT INTO Items (Name, Description, Datasheet) VALUES (@Name, @Description, @Datasheet)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Datasheet", item.Datasheet);

                    return command.ExecuteNonQuery();
                }
            }
        }
        public Item? Read(int Id)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "SELECT Name, Description, Datasheet FROM Items WHERE Id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            string datasheet = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                            return new Item(Id, name, description, datasheet);
                        }
                        else
                        {
                            return null; 
                        }
                    }
                }
            }
        }
        public int ReadBatch(ObservableCollection<Item> itemsObj, int batchSize, int offset)
        {
            itemsObj.Clear();
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "SELECT Id, Name, Description, Datasheet FROM Items LIMIT @BatchSize OFFSET @Offset";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BatchSize", batchSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            string datasheet = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                            itemsObj.Add(new Item(id, name, description, datasheet));
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        public int ReadAll(ObservableCollection<Item> itemsObj)
        {
            itemsObj.Clear();
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "SELECT Id, Name, Description, Datasheet FROM Items";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            string datasheet = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                            itemsObj.Add(new Item(id, name, description, datasheet));
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        public int SearchBatch(ObservableCollection<Item> itemsObj, int batchSize, int offset, string keyWord)
        {
            itemsObj.Clear();
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "SELECT Id, Name, Description, Datasheet FROM Items WHERE Name LIKE @KeyWord OR Description LIKE @KeyWord LIMIT @BatchSize OFFSET @Offset ORDER BY Name";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KeyWord", $"%{keyWord}%");
                    command.Parameters.AddWithValue("@BatchSize", batchSize);
                    command.Parameters.AddWithValue("@Offset", offset);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            string datasheet = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                            itemsObj.Add(new Item(id, name, description, datasheet));
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        public int SearchAll(ObservableCollection<Item> itemsObj, string keyWord)
        {
            itemsObj.Clear();
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "SELECT Id, Name, Description, Datasheet FROM Items WHERE Name LIKE @KeyWord OR Description LIKE @KeyWord ORDER BY Name";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KeyWord", $"%{keyWord}%");
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            string datasheet = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                            itemsObj.Add(new Item(id, name, description, datasheet));
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        public int Update(Item item)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Items WHERE Name = @Name AND Id != @Id";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Name", item.Name);
                    checkCommand.Parameters.AddWithValue("@Id", item.Id);

                    long count = (long)checkCommand.ExecuteScalar(); 
                    if (count > 0)
                    {
                        return -1;
                    }
                }
                string query = "UPDATE Items SET Name = @Name, Description = @Description, Datasheet = @Datasheet WHERE Id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Description", item.Description);
                    command.Parameters.AddWithValue("@Datasheet", item.Datasheet);
                    command.Parameters.AddWithValue("@Id", item.Id);

                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "DELETE FROM Items WHERE Id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Clear()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatabaseFilePath}"))
            {
                connection.Open();
                string query = "DELETE FROM Items";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
