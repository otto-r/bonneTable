﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bonneTable.Admin;

namespace bonneTable.Admin.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    [Migration("20190109190936_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bonneTable.Admin.Entities.DbAdminUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HashedPassword");

                    b.Property<string>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new { Id = new Guid("f06899ea-eae4-45fe-8930-6a0cb983673f"), HashedPassword = "O8OAc+g+w7l/V0aNCdEnYx+3zE3AXqcJMTCB0ylLhhY=", Salt = "eKM5gUWEhws0jPdCxdjrJw==", Username = "test" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
