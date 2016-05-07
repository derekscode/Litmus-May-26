using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Litmus.Entities;

namespace Litmus.Migrations
{
    [DbContext(typeof(LitmusDbContext))]
    partial class LitmusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Litmus.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirthYear");

                    b.Property<string>("CardId");

                    b.Property<string>("Expiration");

                    b.Property<bool>("HasBarcode");

                    b.Property<bool>("HasMagStripe");

                    b.Property<bool>("IsDamaged");

                    b.Property<bool>("IsPaper");

                    b.Property<string>("Location");

                    b.Property<string>("Notes");

                    b.Property<string>("Orientation");

                    b.Property<string>("State");

                    b.Property<string>("Version");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Litmus.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardId");

                    b.Property<DateTime>("DateChanged");

                    b.Property<string>("NewCard");

                    b.Property<string>("OldCard");

                    b.Property<string>("User");

                    b.HasKey("Id");
                });
        }
    }
}
