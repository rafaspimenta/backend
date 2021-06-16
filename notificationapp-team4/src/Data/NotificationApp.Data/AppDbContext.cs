using Microsoft.EntityFrameworkCore;

namespace NotificationApp.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public AppDbContext(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.Database.AutoTransactionsEnabled = false;
        }

        public DbSet<Domain.Models.Channel> Channels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbUnitOfWork = (IDbUnitOfWork)this.unitOfWorkProvider.GetCurrent();
            optionsBuilder.UseMySQL(dbUnitOfWork.Connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Notification>(builder =>
            {
                builder.ToTable("notification");
                builder.HasKey(f => f.Id);
                builder
                    .Property(f => f.Id)
                    .ValueGeneratedOnAdd();

                builder.Property(f => f.ChannelId);
                builder
                    .Property(f => f.Title)
                    .HasMaxLength(256);

                builder
                    .Property(f => f.Url)
                    .HasMaxLength(512);
                builder.Property(f => f.Date);
            });

            modelBuilder.Entity<Domain.Models.Channel>(builder =>
            {
                builder.ToTable("channel");
                builder.HasKey(f => f.Id);
                builder
                    .Property(f => f.Id)
                    .ValueGeneratedOnAdd();

                builder
                    .Property(f => f.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                builder
                    .HasMany(f => f.Notifications)
                    .WithOne(f => f.Channel)
                    .HasForeignKey(f => f.ChannelId);
            });
        }
    }
}
