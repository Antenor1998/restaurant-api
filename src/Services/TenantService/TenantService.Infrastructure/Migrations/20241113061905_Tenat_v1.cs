using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tenat_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tenant");

            migrationBuilder.CreateTable(
                name: "AddOns",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    identifier = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    identifier = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    identifier = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_custom = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_id = table.Column<int>(type: "integer", nullable: false),
                    entity_type = table.Column<string>(type: "text", nullable: false),
                    interval = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    discount_percentage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subscription_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    business_name = table.Column<string>(type: "text", nullable: false),
                    database_connection_string = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trial_ends_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AddOnFeatures",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    add_on_id = table.Column<int>(type: "integer", nullable: false),
                    feature_id = table.Column<int>(type: "integer", nullable: false),
                    increment_value = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnFeatures", x => x.id);
                    table.ForeignKey(
                        name: "FK_AddOnFeatures_AddOns_add_on_id",
                        column: x => x.add_on_id,
                        principalSchema: "tenant",
                        principalTable: "AddOns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddOnFeatures_Features_add_on_id",
                        column: x => x.add_on_id,
                        principalSchema: "tenant",
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanFeatures",
                schema: "tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plan_id = table.Column<int>(type: "integer", nullable: false),
                    feature_id = table.Column<int>(type: "integer", nullable: false),
                    limit_value = table.Column<int>(type: "integer", nullable: true),
                    is_unlimited = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanFeatures", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanFeatures_Features_feature_id",
                        column: x => x.feature_id,
                        principalSchema: "tenant",
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanFeatures_Plans_plan_id",
                        column: x => x.plan_id,
                        principalSchema: "tenant",
                        principalTable: "Plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "AddOns",
                columns: new[] { "id", "created_at", "description", "identifier", "is_active", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340), "Agrega más usuarios al sistema", "EXTRA_USER", true, "Usuarios Adicionales", new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340) },
                    { 2, new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340), "Agrega más sucursales al sistema", "EXTRA_BRANCH", true, "Sucursales Adicionales", new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340) },
                    { 3, new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340), "Agrega más almacenamiento al sistema", "EXTRA_STORAGE", true, "Almacenamiento Adicional", new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(6340) }
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "Features",
                columns: new[] { "id", "created_at", "description", "identifier", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(9990), "Número máximo de usuarios que pueden acceder al sistema", "USERS", "Usuarios", new DateTime(2024, 11, 13, 6, 19, 5, 258, DateTimeKind.Utc).AddTicks(9990) },
                    { 2, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc), "Espacio de almacenamiento en disco", "STORAGE", "Almacenamiento", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc) },
                    { 3, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc), "Soporte técnico", "SUPPORT", "Soporte", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc) },
                    { 4, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc), "Número máximo de sucursales que pueden gestionar", "BRANCHES", "Sucursales", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "Plans",
                columns: new[] { "id", "created_at", "description", "identifier", "is_active", "is_custom", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300), "Plan básico", "BASIC", true, false, "Básico", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300) },
                    { 2, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300), "Plan estándar", "STANDARD", true, false, "Estándar", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300) },
                    { 3, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300), "Plan premium", "PREMIUM", true, false, "Premium", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300) },
                    { 4, new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300), "Plan personalizado", "CUSTOM", true, true, "Personalizado", new DateTime(2024, 11, 13, 6, 19, 5, 259, DateTimeKind.Utc).AddTicks(1300) }
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "Pricings",
                columns: new[] { "id", "currency", "discount_percentage", "entity_id", "entity_type", "interval", "price" },
                values: new object[,]
                {
                    { 1, "MXM", 0, 1, "Plan", "monthly", 100m },
                    { 2, "MXM", 0, 2, "Plan", "monthly", 200m },
                    { 3, "MXM", 0, 3, "Plan", "monthly", 300m },
                    { 4, "MXM", 0, 4, "Plan", "monthly", 400m },
                    { 5, "MXM", 10, 1, "Plan", "yearly", 1000m },
                    { 6, "MXM", 10, 2, "Plan", "yearly", 2000m },
                    { 7, "MXM", 10, 3, "Plan", "yearly", 3000m },
                    { 8, "MXM", 10, 4, "Plan", "yearly", 4000m },
                    { 9, "MXM", 0, 1, "AddOn", "monthly", 10m },
                    { 10, "MXM", 0, 2, "AddOn", "monthly", 20m },
                    { 11, "MXM", 0, 3, "AddOn", "monthly", 30m },
                    { 12, "MXM", 0, 1, "AddOn", "yearly", 100m },
                    { 13, "MXM", 0, 2, "AddOn", "yearly", 200m },
                    { 14, "MXM", 0, 3, "AddOn", "yearly", 300m }
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "AddOnFeatures",
                columns: new[] { "id", "add_on_id", "feature_id", "increment_value" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "PlanFeatures",
                columns: new[] { "id", "feature_id", "is_unlimited", "limit_value", "plan_id" },
                values: new object[,]
                {
                    { 1, 1, false, 5, 1 },
                    { 2, 2, false, 500, 1 },
                    { 3, 3, false, null, 1 },
                    { 4, 4, false, 2, 1 },
                    { 5, 1, false, 10, 2 },
                    { 6, 2, false, 1000, 2 },
                    { 7, 3, false, null, 2 },
                    { 8, 4, false, 5, 2 },
                    { 9, 1, false, 20, 3 },
                    { 10, 2, true, null, 3 },
                    { 11, 3, true, null, 3 },
                    { 12, 4, true, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddOnFeatures_add_on_id",
                schema: "tenant",
                table: "AddOnFeatures",
                column: "add_on_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanFeatures_feature_id",
                schema: "tenant",
                table: "PlanFeatures",
                column: "feature_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanFeatures_plan_id",
                schema: "tenant",
                table: "PlanFeatures",
                column: "plan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOnFeatures",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "PlanFeatures",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "Pricings",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "AddOns",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "tenant");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "tenant");
        }
    }
}
