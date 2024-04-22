using System.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
   
    //public async IEnumerable<Animal>
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using SqlConnection con = new SqlConnection("Server=db-mssql;Database=2019SBD;Integrated Security=True;TrustServerCertificate=True");
        con.Open();
        //"Data Source = db-mssql; Initial Catalog = 2019SBD; Integrated Security = True"
        
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        //cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY @orderBy";
        //cmd.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY @orderBy";
        switch (orderBy.ToLower())
        {
            case "name":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY name";
                break;
            case "description":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY description";
                break;
            case "category":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY category";
                break;
            case "area":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY area";
                break;
        }
        //cmd.Parameters.AddWithValue("@orderBy", orderBy);
        //cmd.Parameters.AddWithValue("orderBy", orderBy);
        
        SqlDataReader sdr = cmd.ExecuteReader();
        List<Animal> animals = new List<Animal>();
        while (sdr.Read())
        {
            Animal animal = new Animal
            {
                IdAnimal = (int)sdr["IdAnimal"],
                Name = sdr["Name"].ToString(),
                Description = sdr["Description"].ToString(),
                Category = sdr["Category"].ToString(),
                Area = sdr["Area"].ToString(),
            };
            animals.Add(animal);
        }
        
        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using SqlConnection con = new SqlConnection("Server=db-mssql;Database=2019SBD;Integrated Security=True;TrustServerCertificate=True");
        con.Open();
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        int affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }

    public int UpdateAnimal(int idAnimal, Animal animal)
    {
        using SqlConnection con = new SqlConnection("Server=db-mssql;Database=2019SBD;Integrated Security=True;TrustServerCertificate=True");
        con.Open();
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        
        int affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using SqlConnection con = new SqlConnection("Server=db-mssql;Database=2019SBD;Integrated Security=True;TrustServerCertificate=True");
        con.Open();
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        int affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }
}