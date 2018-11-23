//using System;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//namespace ST.SharedEntitiesLib
//{
//    public partial class STEFModel : DbContext
//    {
//        public STEFModel()
//            : base("name=STEFModel")
//        {
//            Database.SetInitializer(new STEFModelInitializer());
//        }

//        public virtual DbSet<Product> Product { get; set; }
//        public virtual DbSet<Severity> Severity { get; set; }
//        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
//        public virtual DbSet<Tickets> Tickets { get; set; }
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Product>()
//                .Property(e => e.Description)
//                .IsUnicode(false);

//            modelBuilder.Entity<Severity>()
//                .Property(e => e.DisplayName)
//                .IsUnicode(false);

//            //modelBuilder.Entity<Severity>()
//            //    .HasMany(e => e.Tickets)
//            //    .WithRequired(e => e.Severity)
//            //    .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Tickets>()
//                .Property(e => e.Problem)
//                .IsUnicode(false);

//            modelBuilder.Entity<Tickets>()
//                .Property(e => e.Description)
//                .IsUnicode(false);
//        }
//    }

//    public class STEFModelInitializer : DropCreateDatabaseIfModelChanges<STEFModel>
//    {
//        public STEFModelInitializer()
//        {
//            EnsureEntityFramework();
//        }

//        private static void EnsureEntityFramework()
//        {
//            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
//            if (type == null)
//                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
//        }

//        protected override void Seed(STEFModel context)
//        {
//            using (var ctx = new STEFModel())
//            {
//                var severities = new[] { "Mild", "Medium", "Critical" };
//                severities.ToList().ForEach(s => ctx.Severity.AddOrUpdate(new Severity() { DisplayName = s }));
//                ctx.SaveChanges();

//                for (int n = 1; n <= 3; n++)
//                {
//                    var product = new Product()
//                    {
//                        Description = $"Product{n}",
//                    };

//                    ctx.Product.AddOrUpdate(product);
//                }

//                ctx.SaveChanges();
//            }

//            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
//            var uri = new UriBuilder(codeBase);
//            string path = Uri.UnescapeDataString(uri.Path);
//            path = Path.GetDirectoryName(path);
//            path = $@"{path}\Migrations\vwTicket.sql";
//            context.Database.ExecuteSqlCommand(File.ReadAllText(path));

//            base.Seed(context);
//        }
//    }
//}
