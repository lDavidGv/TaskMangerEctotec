namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initversion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tareas", "Titulo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tareas", "Descripcion", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tareas", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Tareas", "Titulo", c => c.String(nullable: false));
        }
    }
}
