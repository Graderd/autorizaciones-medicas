
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Autorizaciones.Infrastructure.Persistence.Conventions
{
    public static class SnakeCaseConvention
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // No modificar las tablas de ASP.NET Core Identity.
                if (entity.GetTableName()?.StartsWith(
                    "AspNet",
                    StringComparison.OrdinalIgnoreCase) == true)
                {
                    continue;
                }

                foreach (var property in entity.GetProperties())
                {
                    var columnName = property.GetColumnName();

                    if (columnName is not null)
                    {
                        property.SetColumnName(ToSnakeCase(columnName));
                    }
                }

                foreach (var key in entity.GetKeys())
                {
                    var name = key.GetName();

                    if (name is not null)
                    {
                        key.SetName(ToSnakeCase(name));
                    }
                }

                foreach (var index in entity.GetIndexes())
                {
                    var name = index.GetDatabaseName();

                    if (name is not null)
                    {
                        index.SetDatabaseName(ToSnakeCase(name));
                    }
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    var name = foreignKey.GetConstraintName();

                    if (name is not null)
                    {
                        foreignKey.SetConstraintName(ToSnakeCase(name));
                    }
                }
            }
        }

        private static string ToSnakeCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var result = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var current = value[i];

                if (char.IsUpper(current))
                {
                    if (i > 0 &&
                        (char.IsLower(value[i - 1]) ||
                         char.IsDigit(value[i - 1]) ||
                         (i + 1 < value.Length &&
                          char.IsLower(value[i + 1]))))
                    {
                        result.Append('_');
                    }

                    result.Append(char.ToLowerInvariant(current));
                }
                else
                {
                    result.Append(current);
                }
            }

            return result.ToString();
        }
    }
}
