if (File.Exists("users.txt"))
{
    var existingUsers = File.ReadAllLines("users.txt");
    foreach (var line in existingUsers)
    {
        try
        {
            var existingUser = JsonSerializer.Deserialize<JsonElement>(line);
            if (existingUser.TryGetProperty("Username", out var usernameProp) && 
                usernameProp.GetString() == username)
            {
                MessageText.Text = "Пользователь с таким именем уже существует";
                return;
            }
        }
        catch
        {
            continue;
        }
    }
}
