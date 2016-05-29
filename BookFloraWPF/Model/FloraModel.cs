namespace BookFloraWPF.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FloraModel : DbContext
    {
        // Your context has been configured to use a 'FloraModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookFloraWPF.Model.FloraModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FloraModel' 
        // connection string in the application configuration file.
        public FloraModel()
            : base("name=FloraModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Kingdom> Kingdoms { get; set; }
        public virtual DbSet<Phylum> Phylums { get; set; }
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Genus> Genera { get; set; }
        public virtual DbSet<Species> Specieses { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Kingdom>()
            //    .HasKey((k) => k.KingdomId)
            //    .HasMany((k) => k.Phylums)
            //    .WithRequired((p) => p.Kingdom)
            //    .HasForeignKey((p) => p.KingdomForeignKey);
            //modelBuilder.Entity<Kingdom>().Ignore(x => x.IsDirty);


            //modelBuilder.Entity<Phylum>()
            //    .HasKey(p => p.PhylumId)
            //    .HasMany(p => p.Classes)
            //    .WithRequired(c => c.Phylum)
            //    .HasForeignKey(c => c.PhylumForeignKey);
            //modelBuilder.Entity<Phylum>().Ignore(x => x.IsDirty);


            //modelBuilder.Entity<Classe>()
            //    .HasKey(c => c.ClasseId)
            //    .HasMany(c => c.Orders)
            //    .WithRequired(o => o.Classe)
            //    .HasForeignKey(o => o.ClasseForeignKey);
            //modelBuilder.Entity<Classe>().Ignore(x => x.IsDirty);


            //modelBuilder.Entity<Order>()
            //    .HasKey(o => o.OrderId)
            //    .HasMany(o => o.Families)
            //    .WithRequired(f => f.Order)
            //    .HasForeignKey(f => f.OrderForeignKey);
            //modelBuilder.Entity<Order>().Ignore(x => x.IsDirty);


            //modelBuilder.Entity<Family>()
            //    .HasKey(f => f.FamilyId)
            //    .HasMany(f => f.Genera)
            //    .WithRequired(g => g.Family)
            //    .HasForeignKey(g => g.FamilyForeignKey);
            //modelBuilder.Entity<Family>().Ignore(x => x.IsDirty);


            //modelBuilder.Entity<Genus>()
            //    .HasKey(g => g.GenusId)
            //    .HasMany(g => g.Specieses)
            //    .WithRequired(s => s.Genus)
            //    .HasForeignKey(s => s.GenusForeignKey);
            //modelBuilder.Entity<Genus>().Ignore(x => x.IsDirty);

            //modelBuilder.Entity<Species>()
            //    .HasKey(s => s.SpeciesId)
            //    .HasMany(s => s.Photos)
            //    .WithRequired(p => p.Species)
            //    .HasForeignKey(p => p.SpeciesForeignKey);
            //modelBuilder.Entity<Species>().Ignore(x => x.IsDirty);

            //modelBuilder.Entity<Photo>().HasKey(p => p.PhotoId);
        }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}