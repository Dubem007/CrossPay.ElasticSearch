using CrossPay.ElasticSearch.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CrossPay.ElasticSearch.Data
{
    public class CrossBordaDbContext : DbContext
    {
        public CrossBordaDbContext(DbContextOptions<CrossBordaDbContext> options)
         : base(options)
        {

        }

        public DbSet<WalletTransactions> WalletTransactions { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AppConfig> AppConfig { get; set; }
        public DbSet<TransactionPin> TransactionPins { get; set; }
        public DbSet<EmailHistory> EmailHistories { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletConfiguration> WalletConfigurations { get; set; }
        public DbSet<WalletConversion> WalletConversion { get; set; }
        public DbSet<InAppNotification> InAppNotifications { get; set; }
        public DbSet<Markup> Markups { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<RolePermissionMapping> RolePermissionMappings { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public DbSet<TransactionQuotation> TransactionQuotations { get; set; }
        public DbSet<OutboundTransaction> OutboundTransactions { get; set; }
        public DbSet<WaitList> WaitLists { get; set; }
        public DbSet<ResetToken> ResetTokens { get; set; }
        public DbSet<AccountTier> AccountTier { get; set; }
        public DbSet<TransactionCharge> TransactionCharges { get; set; }
        public DbSet<PaymentProvider> PaymentProviders { get; set; }
        public DbSet<TransferRate> TransferRates { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Relationships> Relationships { get; set; }
        public DbSet<SourceOfFunds> SourceOfFunds { get; set; }
        public DbSet<Purpose> Purpose { get; set; }


    }
}
