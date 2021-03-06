// <auto-generated />
using System;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.PostgreSQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210702000255_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataAccess.PostgreSQL.TestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("TestPropertyInt")
                        .HasColumnType("integer");

                    b.Property<string>("TestPropertyString")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
