namespace SistemaPrestamos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(),
                        Correo = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Prestamoes",
                c => new
                    {
                        PrestamoID = c.Int(nullable: false, identity: true),
                        Plazo = c.Int(nullable: false),
                        Interes = c.Double(nullable: false),
                        CantidadPrestada = c.Double(nullable: false),
                        Cuota = c.Double(nullable: false),
                        IniciodePrestamo = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrestamoID)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true);


        }
        
        public override void Down()
        {
            DropTable("dbo.Prestamoes");
            DropTable("dbo.Clientes");
        }
    }
}
