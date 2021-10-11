using Calendar.Dal.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal.DbConfig
{
   public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
        //    builder.ToTable("Appointment", "dbo");
        //    builder.HasKey(x => x.Id).HasName("PK_Appointment").IsClustered();

        //    builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
        //    builder.Property(x => x.Date).HasColumnName(@"Date").HasColumnType("datetime").IsRequired(false);
        //    builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(250)").IsRequired(false).HasMaxLength(250);
        //    builder.Property(x => x.CreatedAt).HasColumnName(@"CreatedAt").HasColumnType("datetime").IsRequired(false);
        //    builder.Property(x => x.Organizer).HasColumnName(@"Organizer").HasColumnType("int").IsRequired(false);
        //    builder.Property(x => x.Attendees).HasColumnName(@"Attendees").HasColumnType("int").IsRequired(false);
        //    builder.Property(x => x.MonthId).HasColumnName(@"MonthId").HasColumnType("int").IsRequired(false);

        //    // Foreign keys
        //    builder.HasOne(a => a.Month).WithMany(b => b.Appointments).HasForeignKey(c => c.MonthId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Appointment_Appointment");
        //    builder.HasOne(a => a.User).WithMany(b => b.Appointments).HasForeignKey(c => c.Organizer).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Appointment_User");
        }
    }
}
