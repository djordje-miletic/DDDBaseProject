using FluentMigrator.Builders.Create.Table;

namespace DDD.Migrations.Extensions
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                    .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .PrimaryKey()
                    .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithGuidIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                    .WithColumn("Id")
                    .AsGuid()
                    .NotNullable()
                    .PrimaryKey();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithAuditColumns(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                    .WithColumn("CreatedAt").AsDateTime().Nullable()
                    .WithColumn("ModifiedAt").AsDateTime().Nullable()
                    .WithColumn("CreatedBy").AsString(50).Nullable()
                    .WithColumn("ModifiedBy").AsString(50).Nullable();
        }
    }
}
