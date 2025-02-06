using System.Text.Json;

namespace TextbookManager.Data
{
    public static class DBManager
    {
        public static MergeModelClasses ReadJsonFileToList(string jsonFileName)
        {
            MergeModelClasses jsonDatabase = new MergeModelClasses();
            try
            {
                string jsonText = File.ReadAllText("DB/data.json");
                var jsonData = JsonSerializer.Deserialize<MergeModelClasses>(jsonText);
                if (jsonData != null)
                {
                    jsonDatabase.Institutions = jsonData.Institutions;
                    jsonDatabase.Authors = jsonData.Authors;
                    jsonDatabase.Textbooks = jsonData.Textbooks;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file was not found");
            }
            catch (JsonException)
            {
                Console.WriteLine($"An error occurred while processing the JSON");
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred");
            }
            return jsonDatabase;
        }
        public static bool UpdateDB(MergeModelClasses mergeModelClasses)
        {

            string jsonString = JsonSerializer.Serialize(mergeModelClasses);
            try
            {
                var filePath = "DB/data.json";
                string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in

                var saveJson = JsonSerializer.Serialize(mergeModelClasses, new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    WriteIndented = true,
                });
                File.WriteAllText(filePath, saveJson);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during saving");
                return false;
            }
            return true;
        }
    }
}

