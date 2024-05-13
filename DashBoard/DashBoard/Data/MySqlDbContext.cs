using DashBoard.Models;
using Microsoft.EntityFrameworkCore;
namespace DashBoard.Data
{
    public partial class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {

        }
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<PayRate> PayRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeNumber, e.PayRatesIdPayRates })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("employee");

                entity.HasIndex(e => e.EmployeeNumber, "Employee Number_UNIQUE").IsUnique();

                entity.HasIndex(e => e.PayRatesIdPayRates, "fk_Employee_Pay Rates_idx");

                entity.Property(e => e.EmployeeNumber).HasColumnName("Employee Number");
                entity.Property(e => e.PayRatesIdPayRates).HasColumnName("Pay Rates_idPay Rates");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("First Name");
                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .HasColumnName("Last Name");
                entity.Property(e => e.PaidLastYear)
                    .HasPrecision(2)
                    .HasColumnName("Paid Last Year");
                entity.Property(e => e.PaidToDate)
                    .HasPrecision(2)
                    .HasColumnName("Paid To Date");
                entity.Property(e => e.PayRate)
                    .HasMaxLength(40)
                    .HasColumnName("Pay Rate");
                entity.Property(e => e.Ssn)
                    .HasPrecision(10)
                    .HasColumnName("SSN");
                entity.Property(e => e.VacationDays).HasColumnName("Vacation Days");

                entity.HasOne(d => d.PayRatesIdPayRatesNavigation).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PayRatesIdPayRates)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Employee_Pay Rates");
            });

            modelBuilder.Entity<PayRate>(entity =>
            {
                entity.HasKey(e => e.IdPayRates).HasName("PRIMARY");

                entity.ToTable("pay rates");

                entity.Property(e => e.IdPayRates)
                    .ValueGeneratedNever()
                    .HasColumnName("idPay Rates");
                entity.Property(e => e.PayAmount)
                    .HasPrecision(10)
                    .HasColumnName("Pay Amount");
                entity.Property(e => e.PayRateName)
                    .HasMaxLength(40)
                    .HasColumnName("Pay Rate Name");
                entity.Property(e => e.PayType).HasColumnName("Pay Type");
                entity.Property(e => e.PtLevelC)
                    .HasPrecision(10)
                    .HasColumnName("PT - Level C");
                entity.Property(e => e.TaxPercentage)
                    .HasPrecision(10)
                    .HasColumnName("Tax Percentage");
                entity.Property(e => e.Value).HasPrecision(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
