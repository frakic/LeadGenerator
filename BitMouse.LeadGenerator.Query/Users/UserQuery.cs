using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Infrastructure.Settings;
using System.Data;
using System.Data.SqlClient;

namespace BitMouse.LeadGenerator.Query.Users;

public class UserQuery : IUserQuery
{
    private readonly ConnectionStrings _connectionStrings;

    public UserQuery(ConnectionStrings connectionStrings)
    {
        _connectionStrings = connectionStrings;
    }

    public async Task<DateTime?> GetDateCreatedByEmailAsync(string email)
    {
        using SqlConnection connection = new(_connectionStrings.LeadGenerator);
        await connection.OpenAsync();

        using SqlCommand command = new("User.spGetDateCreatedByEmail", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Email", email);

        var queryResult = (DateTime?)await command.ExecuteScalarAsync();

        return queryResult;
    }

    public async Task<IEnumerable<BusinessUserDto>> GetBusinessUsersAsync(string email)
    {
        throw new NotImplementedException();
    }
}
