using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagement.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class auditdbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    AuditTransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditId = table.Column<long>(type: "bigint", nullable: false),
                    Refnumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartnerReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConfirmedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OfferId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ToCurr = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PartnerMTAI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sarb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrincipleSpreadDCMZAR = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    XEDCM = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    HPAfterMarkUp = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    ZARTotalSpread = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    HPZARSpread = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMZARSpread = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMUSDSpread = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    TotalTransFee = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    HPTransFeeZAR = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMTransFeeZAR = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMTransFeeUSD = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    OfferAmount = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    Base = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    MarkUp = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    Randdiff = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    Perc = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCM = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    USDMarkUp = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    USDPerc = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMZAR = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMZARMarkUp = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DCMZARPerc = table.Column<decimal>(type: "decimal(20,10)", nullable: true),
                    DaytonaUSDBase = table.Column<decimal>(type: "decimal(30,15)", nullable: true),
                    DaytonaUSDMarkUp = table.Column<decimal>(type: "decimal(30,15)", nullable: true),
                    DaytonaPerc = table.Column<decimal>(type: "decimal(18,15)", nullable: true),
                    DaytonaZARBase = table.Column<decimal>(type: "decimal(18,15)", nullable: true),
                    DaytonaZARMarkUp = table.Column<decimal>(type: "decimal(18,15)", nullable: true),
                    DaytonaZARPerc = table.Column<decimal>(type: "decimal(18,15)", nullable: true),
                    InternalServiceFeeZAR = table.Column<decimal>(type: "decimal(30,15)", nullable: true),
                    InternalServiceFeeUSD = table.Column<decimal>(type: "decimal(30,15)", nullable: true),
                    MatchStatus = table.Column<int>(type: "int", nullable: false),
                    PartnerStatus = table.Column<int>(type: "int", nullable: false),
                    DTBaseLive = table.Column<decimal>(type: "decimal(30,15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.AuditTransactionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
