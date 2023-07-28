using Microsoft.EntityFrameworkCore;
using Veterinaria.Modelos;

namespace Veterinaria;

public class VetarinariaContext: DbContext
{
   public DbSet<Address_Customer> Address_Customer {get;set;}
   public DbSet<Address_Supplier> Address_Supplier {get;set;}
   public DbSet<Date> Date {get;set;}
   public DbSet<Doctors> Doctors{get;set;}
   public DbSet<Master_customer> Master_customer {get;set;}
   public DbSet<Master_product> Master_product {get;set;}
   public DbSet<Master_supplier> Master_supplier {get;set;}
   public DbSet<Payment_Method> Payment_Method {get;set;}
   public DbSet<Pets_customer> Pets_customer {get;set;}
   public DbSet<Purchase_order> Purchase_order {get;set;}
   public DbSet<Store> Store {get;set;}
   public DbSet<Trade_transaction> Trade_transaction {get;set;}
   public VetarinariaContext(DbContextOptions<VetarinariaContext> options) :base (options) { }

   protected override void OnModelCreating(ModelBuilder modelBuilder){
      modelBuilder.Entity<Address_Customer>(Address_Customer =>
      {
         Address_Customer.ToTable("Address_Customer","TNXT");
         Address_Customer.HasKey(t => t.Id);

         Address_Customer.HasOne(t => t.Master_customer)
                        .WithMany(t => t.Address_Customer)
                        .HasForeignKey(t => t.Master_customerId);

         Address_Customer.Property(t =>t.Direccion).IsRequired().HasMaxLength(100); 
      });

      modelBuilder.Entity<Address_Supplier>(Address_Supplier =>
      {
         Address_Supplier.ToTable("Address_Supplier","TNXT");
         Address_Supplier.HasKey(t => t.Id);

         Address_Supplier.HasOne(t => t.Master_supplier)
                        .WithMany(t => t.Address_Supplier)
                        .HasForeignKey(t=> t.Master_supplierId);

         Address_Supplier.Property(t=> t.Direccion).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Date>(Date =>
      {
         Date.ToTable("Date","Master");
         Date.HasKey(t=> t.Id);

         Date.HasOne(t=> t.Doctors)
            .WithMany(t=> t.Date)
            .HasForeignKey(t=> t.DoctorsId);

         Date.HasOne(t=> t.Master_customer)
            .WithMany(t=> t.Date)
            .HasForeignKey(t=> t.Master_customerId);
         
         Date.Property(t=> t.Fecha_cita).IsRequired();
      });

      modelBuilder.Entity<Doctors>(Doctors =>
      {
         Doctors.ToTable("Doctors","Master");
         Doctors.HasKey(t=> t.Id);

         Doctors.HasOne(t=> t.Store)
               .WithMany(t=> t.Doctors)
               .HasForeignKey(t=> t.StoreId);
         
         Doctors.Property(t=> t.Nombre_Doctor).IsRequired().HasMaxLength(100);
         Doctors.Property(t=> t.Especialidad).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Master_customer>(Master_customer =>
      {
         Master_customer.ToTable("Customer","Master");
         Master_customer.Property(t=> t.Email).IsRequired().HasMaxLength(100);
         Master_customer.Property(t=> t.Contraseña).IsRequired().HasMaxLength(100);
         Master_customer.Property(t=> t.Nombre).IsRequired().HasMaxLength(100);
         Master_customer.Property(t=> t.Direccion).IsRequired().HasMaxLength(100);
         Master_customer.Property(t=> t.Celular).IsRequired(false).HasMaxLength(100);
      });

      modelBuilder.Entity<Master_product>(Master_product =>
      {
         Master_product.ToTable("Product","Master");
         Master_product.HasKey(t=> t.id);

         Master_product.HasOne(t=> t.Store)
                     .WithMany(t=> t.Master_product)
                     .HasForeignKey(t=> t.StoreId);

         Master_product.Property(t=> t.Nombre_Producto).IsRequired().HasMaxLength(100);
         Master_product.Property(t=> t.Marca).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Master_supplier>(Master_supplier =>
      {
         Master_supplier.ToTable("Supplier","Master");
         Master_supplier.HasKey(t=> t.Id);

         Master_supplier.HasOne(t=> t.Master_product)
                        .WithMany(t=> t.Master_supplier)
                        .HasForeignKey(t=> t.Master_productId);

         Master_supplier.Property(t=> t.Nombre_proveedor).IsRequired().HasMaxLength(100);

      });

      modelBuilder.Entity<Payment_Method>(Payment_Method =>
      {
         Payment_Method.ToTable("Method","Pyment");
         Payment_Method.HasKey(t=> t.Id);
         Payment_Method.Property(t=> t.Metodo_tarjeta).IsRequired().HasMaxLength(100);
         Payment_Method.Property(t=> t.Efectivo).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Pets_customer>(Pets_customer =>
      {
         Pets_customer.ToTable("PetsCustomer");
         Pets_customer.HasKey(t=> t.Id);

         Pets_customer.HasOne(t => t.Master_customer)
                      .WithMany(t=> t.Pets_customer)
                      .HasForeignKey(t=> t.Master_customerId); 

         Pets_customer.Property(t=> t.Nombre_Mascota).IsRequired().HasMaxLength(100);
         Pets_customer.Property(t=> t.Edad).IsRequired().HasMaxLength(100);

      });

      modelBuilder.Entity<Purchase_order>(Purchase_order =>
      {
         Purchase_order.ToTable("Purchase_order","TNXT");
         Purchase_order.HasKey(t=> t.Id);

         Purchase_order.HasOne(t=> t.Master_product)
                     .WithMany(t=> t.Purchase_order)
                     .HasForeignKey(t=> t.Master_productId);

         Purchase_order.HasOne(t=> t.Address_Customer)
                     .WithMany(t=> t.Purchase_order)
                     .HasForeignKey(t=> t.Address_CustomerId);

         Purchase_order.HasOne(t=> t.Trade_transaction)
                        .WithMany(t=> t.Purchase_Orders)
                        .HasForeignKey(t=> t.Master_productId);

         Purchase_order.Property(t=> t.Cantidad).IsRequired();
      });

      modelBuilder.Entity<Store>(Store =>
      {
         Store.ToTable("Store","Master");
         Store.HasKey(t=> t.Id);

         Store.Property(t=> t.Direccion).IsRequired().HasMaxLength(100);
         Store.Property(t=> t.Nombre_Punto_venta).IsRequired().HasMaxLength(100);
      });

      modelBuilder.Entity<Trade_transaction>(Trade_transaction =>
      {
         Trade_transaction.ToTable("Trade_transaction", "TNXT");
         Trade_transaction.HasKey(t=> t.Id);

         Trade_transaction.HasOne(t=> t.Payment_Method)
                           .WithOne(t=> t.Trade_transaction)
                           .HasForeignKey<Trade_transaction>(t => t.Payment_MethodId);
      });

   }
}