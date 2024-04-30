using AuditManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditManagement.DataAcces.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<AuditTransaction>
    {
        public void Configure(EntityTypeBuilder<AuditTransaction> modelBuilder)
        {
            modelBuilder.HasKey(x => x.AuditTransactionId);

            modelBuilder.Property(p => p.AuditTransactionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Property(e => e.Refnumber).HasMaxLength(50);
            modelBuilder.Property(e => e.PartnerReference).HasMaxLength(50);

            modelBuilder.Property(e => e.TransactionDate).HasColumnType("date");

            modelBuilder.Property(e => e.Country).HasMaxLength(100);  

            modelBuilder.Property(e => e.ToCurr).HasMaxLength(3);

            modelBuilder.Property(e => e.Bank).HasMaxLength(50);

            modelBuilder.Property(e => e.PartnerMTAI).HasMaxLength(50);

            modelBuilder.Property(e => e.Sarb).HasMaxLength(50);

            modelBuilder.Property(e => e.PrincipleSpreadDCMZAR).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.TotalAmount).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.XEDCM).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.HPAfterMarkUp).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.ZARTotalSpread).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.HPZARSpread).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMZARSpread).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMUSDSpread).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.TotalTransFee).HasColumnType("decimal(10,5)");
            modelBuilder.Property(e => e.HPTransFeeZAR).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMTransFeeZAR).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMTransFeeUSD).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.OfferAmount).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.Base).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.MarkUp).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.Randdiff).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.Perc).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCM).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.USDMarkUp).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.USDPerc).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMZAR).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMZARMarkUp).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DCMZARPerc).HasColumnType("decimal(20,10)");
            modelBuilder.Property(e => e.DaytonaUSDBase).HasColumnType("decimal(30, 15)");
            modelBuilder.Property(e => e.DaytonaUSDMarkUp).HasColumnType("decimal(30, 15)");
            modelBuilder.Property(e => e.DaytonaPerc).HasColumnType("decimal((30, 15))");
            modelBuilder.Property(e => e.DaytonaZARBase).HasColumnType("decimal((30, 15))");
            modelBuilder.Property(e => e.DaytonaZARMarkUp).HasColumnType("decimal((30, 15))");
            modelBuilder.Property(e => e.DaytonaZARPerc).HasColumnType("decimal((30, 15))");
            modelBuilder.Property(e => e.InternalServiceFeeZAR).HasColumnType("decimal(30, 15)");
            modelBuilder.Property(e => e.InternalServiceFeeUSD).HasColumnType("decimal(30, 15)");
            modelBuilder.Property(e => e.DTBaseLive).HasColumnType("decimal(30, 15)");
        }
    }
}