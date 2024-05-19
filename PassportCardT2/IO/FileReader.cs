namespace PassportCardT2.IO
{
    public class FileReader
    {
        public string? ReadFileContent(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Logger.WriteError($"Error reading file: {ex.Message}");
                return null;
            }
        }
    }
}
