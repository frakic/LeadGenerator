using BitMouse.LeadGenerator.Model.Users;
using BitMouse.LeadGenerator.Repository.Settings;
using System.Data;
using System.Data.SqlClient;

namespace BitMouse.LeadGenerator.Repository.Users;

public class UserRepository : IUserRepository
{
    private readonly ConnectionStrings _connectionStrings;

    public UserRepository(ConnectionStrings connectionStrings)
    {
        _connectionStrings = connectionStrings;
    }

    public async Task InsertAsync(User user)
    {
        using SqlConnection connection = new(_connectionStrings.LeadGenerator);
        await connection.OpenAsync();

        using SqlCommand command = new("User.spInsertUser", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@FirstName", user.FirstName);
        command.Parameters.AddWithValue("@LastName", user.LastName);
        command.Parameters.AddWithValue("@Email", user.ContactDetails.Email);

        command.ExecuteNonQuery();
    }

    public async Task<DateTime?> GetDateCreatedByEmail(string email)
    {
        using SqlConnection connection = new(_connectionStrings.LeadGenerator);
        await connection.OpenAsync();

        using SqlCommand command = new("User.spGetDateCreatedByEmail", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Email", email);

        var queryResult = (DateTime?)await command.ExecuteScalarAsync();

        return queryResult;
    }
}
