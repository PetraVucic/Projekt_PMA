// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMA_Projekt_Brodovi.Models;

namespace PMA_Projekt_Brodovi.Migrations
{
    [DbContext(typeof(ShipContext))]
    [Migration("20210730104423_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMA_Projekt_Brodovi.Models.Brod", b =>
                {
                    b.Property<int>("BrodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeBroda")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RegistracijskeOznake")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("SvojstvaBrodaId")
                        .HasColumnType("int");

                    b.Property<int>("VlasnikId")
                        .HasColumnType("int");

                    b.HasKey("BrodId");

                    b.HasIndex("SvojstvaBrodaId");

                    b.HasIndex("VlasnikId");

                    b.ToTable("Brodovi");
                });

            modelBuilder.Entity("PMA_Projekt_Brodovi.Models.SvojstvaBroda", b =>
                {
                    b.Property<int>("SvojstvaBrodaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boja")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MarkaBroda")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModelBroda")
                        .HasColumnType("varchar(100)");

                    b.HasKey("SvojstvaBrodaId");

                    b.ToTable("SvojstvaBrodova");
                });

            modelBuilder.Entity("PMA_Projekt_Brodovi.Models.Vlasnik", b =>
                {
                    b.Property<int>("VlasnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeVlasnika")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("OibVlasnika")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PrezimeVlasnika")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("VlasnikId");

                    b.ToTable("Vlasnici");
                });

            modelBuilder.Entity("PMA_Projekt_Brodovi.Models.Brod", b =>
                {
                    b.HasOne("PMA_Projekt_Brodovi.Models.SvojstvaBroda", "SvojstvaBroda")
                        .WithMany()
                        .HasForeignKey("SvojstvaBrodaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMA_Projekt_Brodovi.Models.Vlasnik", "Vlasnik")
                        .WithMany()
                        .HasForeignKey("VlasnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SvojstvaBroda");

                    b.Navigation("Vlasnik");
                });
#pragma warning restore 612, 618
        }
    }
}
