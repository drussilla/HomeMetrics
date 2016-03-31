using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using HomeMetrics.Collector.DAL.EF;

namespace HomeMetrics.Collector.DAL.EF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20160331214927_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("HomeMetrics.Collector.DAL.Models.Reading", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CollectedDateTime");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<float>("Data");

                    b.Property<Guid>("SensorId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("HomeMetrics.Collector.DAL.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("HomeMetrics.Collector.DAL.Models.Reading", b =>
                {
                    b.HasOne("HomeMetrics.Collector.DAL.Models.Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId");
                });
        }
    }
}
