// <auto-generated />
using Formula1_DAW.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Formula1_DAW.Migrations
{
    [DbContext(typeof(ContextDAW))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Formula1_DAW.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTeam");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("Formula1_DAW.Models.SponsorTeam", b =>
                {
                    b.Property<int>("IdSponsor")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.HasKey("IdSponsor", "IdTeam");

                    b.HasIndex("IdTeam");

                    b.ToTable("SponsorTeam");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdTeamPrincipal")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTeamPrincipal")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Formula1_DAW.Models.TeamPrincipal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeamPrincipal");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Formula1_DAW.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Driver", b =>
                {
                    b.HasOne("Formula1_DAW.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Formula1_DAW.Models.SponsorTeam", b =>
                {
                    b.HasOne("Formula1_DAW.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("IdSponsor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Formula1_DAW.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sponsor");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Team", b =>
                {
                    b.HasOne("Formula1_DAW.Models.TeamPrincipal", "TeamPrincipal")
                        .WithOne()
                        .HasForeignKey("Formula1_DAW.Models.Team", "IdTeamPrincipal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamPrincipal");
                });

            modelBuilder.Entity("Formula1_DAW.Models.Track", b =>
                {
                    b.HasOne("Formula1_DAW.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
