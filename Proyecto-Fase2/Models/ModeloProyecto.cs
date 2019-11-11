namespace Proyecto_Fase2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloProyecto : DbContext
    {
        public ModeloProyecto()
            : base("name=ModeloProyecto")
        {
        }

        public virtual DbSet<AccoutingBook> AccoutingBook { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<DPBR> DPBR { get; set; }
        public virtual DbSet<LatePayment> LatePayment { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPurchase> ProductPurchase { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<PurcharseDetails> PurcharseDetails { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sub_Category> Sub_Category { get; set; }
        public virtual DbSet<SubCategory_Provider> SubCategory_Provider { get; set; }
        public virtual DbSet<SuplyInvoice> SuplyInvoice { get; set; }
        public virtual DbSet<SuplyProduct> SuplyProduct { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<TokenConnection> TokenConnection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccoutingBook>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccoutingBook>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AccoutingBook>()
                .HasMany(e => e.SuplyInvoice)
                .WithOptional(e => e.AccoutingBook)
                .HasForeignKey(e => e.Id_AccountingBook);

            modelBuilder.Entity<Area>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.AccoutingBook)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Id_Area);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Id_Area);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Sub_Category)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Id_Category);

            modelBuilder.Entity<LatePayment>()
                .Property(e => e.Increment)
                .HasPrecision(3, 2);

            modelBuilder.Entity<LatePayment>()
                .Property(e => e.TypeIncrement)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LatePayment>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LatePayment>()
                .HasMany(e => e.ProductPurchase)
                .WithOptional(e => e.LatePayment)
                .HasForeignKey(e => e.Id_LatePayment);

            modelBuilder.Entity<LatePayment>()
                .HasMany(e => e.SuplyInvoice)
                .WithOptional(e => e.LatePayment)
                .HasForeignKey(e => e.Id_LatePayment);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Module)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.DPBR)
                .WithOptional(e => e.Permission)
                .HasForeignKey(e => e.Id_Permission);

            modelBuilder.Entity<Phone>()
                .Property(e => e.Number_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Internal_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SuplyProduct)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Id_Product);

            modelBuilder.Entity<ProductPurchase>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProductPurchase>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductPurchase>()
                .HasMany(e => e.PurcharseDetails)
                .WithOptional(e => e.ProductPurchase)
                .HasForeignKey(e => e.Id_Purcharse);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.NIT)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.SubCategory_Provider)
                .WithOptional(e => e.Provider)
                .HasForeignKey(e => e.Id_Provider);

            modelBuilder.Entity<PurcharseDetails>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.DPBR)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Id_Role);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Id_Role);

            modelBuilder.Entity<Sub_Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Category>()
                .HasMany(e => e.SubCategory_Provider)
                .WithOptional(e => e.Sub_Category)
                .HasForeignKey(e => e.Id_SCategory);

            modelBuilder.Entity<SubCategory_Provider>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.SubCategory_Provider)
                .HasForeignKey(e => e.Id_SCP);

            modelBuilder.Entity<SuplyInvoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SuplyInvoice>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuplyInvoice>()
                .HasMany(e => e.SuplyProduct)
                .WithOptional(e => e.SuplyInvoice)
                .HasForeignKey(e => e.Id_SuplyInvoice);

            modelBuilder.Entity<SuplyProduct>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SuplyProduct>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SuplyProduct>()
                .HasMany(e => e.PurcharseDetails)
                .WithOptional(e => e.SuplyProduct)
                .HasForeignKey(e => e.Id_SuplyProduct);

            modelBuilder.Entity<Users>()
                .Property(e => e.Credentials)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name1)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name2)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LName1)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LName2)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Phone)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.Id_User);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ProductPurchase)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.Id_User);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.Id_User);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Chief_Area)
                .IsFixedLength()
                .IsUnicode(false);
        }

       
    }
}
