using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeTrade.Database.Migrastions
{
    [Migration(1)]
    public class DatabaseTables : Migration
    {
        public override void Up()
        { 
            
            Create.Table("User")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Email").AsString(255).NotNullable().Unique()
                .WithColumn("Password").AsString(255).NotNullable()
                .WithColumn("FullName").AsString(255).NotNullable();

            Create.Table("TradeItem")
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Title").AsString(255).NotNullable()
               .WithColumn("Item").AsString(255).Nullable()
               .WithColumn("ExchangeFee").AsDouble()
               .WithColumn("ExchangeItem").AsString(255)
               .WithColumn("UserId").AsInt64().NotNullable();

           

            Create.ForeignKey("fk_User_TradeItem_UserId")
                .FromTable("TradeItem").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("TradeItem");
            Delete.Table("User");
        }
    }
}
