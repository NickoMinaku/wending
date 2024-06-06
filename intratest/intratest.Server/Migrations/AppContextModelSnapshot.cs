﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using intratest.Server;

#nullable disable

namespace intratest.Server.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("intratest.Server.models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 150,
                            Name = "Кола",
                            Path = "./drinks/1.png",
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            Cost = 100,
                            Name = "Спрайт",
                            Path = "./drinks/2.png",
                            Quantity = 7
                        },
                        new
                        {
                            Id = 3,
                            Cost = 130,
                            Name = "Фанта",
                            Path = "./drinks/3.png",
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            Cost = 60,
                            Name = "Милкис",
                            Path = "./drinks/4.png",
                            Quantity = 7
                        },
                        new
                        {
                            Id = 5,
                            Cost = 110,
                            Name = "Квас",
                            Path = "./drinks/5.png",
                            Quantity = 20
                        },
                        new
                        {
                            Id = 6,
                            Cost = 200,
                            Name = "Яблочный сок",
                            Path = "./drinks/6.png",
                            Quantity = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
