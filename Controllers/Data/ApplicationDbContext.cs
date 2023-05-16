using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<Engineer> Engineers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<ProjectPhase> ProjectPhases { get; set; }

        public DbSet<Deliverable> Deliverables { get; set; }

        public DbSet<PaymentTerm> PaymentTerms { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<ProjectManager> ProjectManagers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-VVERATU;Database=PMIS;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PMISrahaf0;Data Source=DESKTOP-L4B9EC9\\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
         //   builder.Entity<ProjectPhase>().HasKey(x => x.ProjectPhaseId);

            builder.Entity<InvoicePaymentTerm>().HasKey(x => new { x.InvoiceId, x.PaymentTermId });


            //builder.Entity<AspNetRoleClaims>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId);

            //    entity.Property(e => e.RoleId).IsRequired();

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //builder.Entity<AspNetRoles>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName)
            //        .HasName("RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //builder.Entity<AspNetUserClaims>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId);

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //builder.Entity<AspNetUserLogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId);

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //builder.Entity<AspNetUserRoles>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasIndex(e => e.RoleId);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //builder.Entity<AspNetUserTokens>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            //builder.Entity<AspNetUsers>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail)
            //        .HasName("EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName)
            //        .HasName("UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Discriminator).IsRequired();

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});
            /*
                        builder.Entity<Deliverable>(entity =>
                        {
                            entity.HasKey(e => e.DeliverableId);

                            entity.HasIndex(e => e.ProjectPhaseId);

                            entity.HasOne(d => d.ProjectPhase)
                                .WithMany(p => p.Deliverables)
                                .HasForeignKey(d => d.ProjectPhaseId);
                        });

                        builder.Entity<InvoicePaymentTerm>(entity =>
                        {
                            entity.HasKey(e => new { e.InvoiceId, e.PaymentTermId });

                            entity.HasIndex(e => e.PaymentTermId);

                            entity.HasOne(d => d.Invoice)
                                .WithMany(p => p.InvoicePaymentTerms)
                                .HasForeignKey(d => d.InvoiceId);

                            entity.HasOne(d => d.PaymentTerm)
                                .WithMany(p => p.InvoicePaymentTerms)
                                .HasForeignKey(d => d.PaymentTermId);
                        });

                        builder.Entity<Invoice>(entity =>
                        {
                            entity.HasKey(e => e.InvoiceId);
                        });

                        builder.Entity<PaymentTerm>(entity =>
                        {
                            entity.HasKey(e => e.PaymentTermId);

                            entity.HasIndex(e => e.DeliverableId);

                            entity.Property(e => e.PaymentTermAmount).HasColumnType("decimal(18, 2)");

                            entity.HasOne(d => d.Deliverable)
                                .WithMany(p => p.PaymentTerms)
                                .HasForeignKey(d => d.DeliverableId);
                        });

                        builder.Entity<Phase>(entity =>
                        {
                            entity.HasKey(e => e.PhaseId);
                        });

                        builder.Entity<ProjectPhase>(entity =>
                        {
                            entity.HasKey(e => e.ProjectPhaseId);

                            entity.HasIndex(e => e.PhaseId);

                            entity.HasIndex(e => e.ProjectId);

                            entity.Property(e => e.DateTime).HasColumnName("dateTime");

                            entity.HasOne(d => d.Phase)
                                .WithMany(p => p.ProjectPhases)
                                .HasForeignKey(d => d.PhaseId);

                            entity.HasOne(d => d.Project)
                                .WithMany(p => p.ProjectPhases)
                                .HasForeignKey(d => d.ProjectId);
                        });

                        builder.Entity<ProjectStatus>(entity =>
                        {
                            entity.HasKey(e => e.ProjectStatusId);
                        });

                        builder.Entity<ProjectType>(entity =>
                        {
                            entity.HasKey(e => e.ProjectTypeId);
                        });*/

            /*builder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                *//*entity.HasIndex(e => e.ProjectManagerId);

                entity.HasIndex(e => e.ProjectStatusId);

                entity.HasIndex(e => e.ProjectTypeId);

                entity.Property(e => e.ContractAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectManagerId);

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId);

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId);
            });

            OnModelCreatingPartial(modelBuilder);*//*
            });*/


        }
    }
}

    






//builder.Entity<Project>().HasOne(x => x.ProjectStatus)
//    .WithMany(x => x.Project)
//    .HasForeignKey(s => s.ProjectStatusId);

//builder.Entity<Project>().HasOne(x => x.ProjectType)
//  .WithMany(x => x.Project)
//  .HasForeignKey(s => s.ProjectTypeId);


//builder.Entity<Deliverable>().HasOne(x => x.ProjectPhase)
//  .WithMany(c => c.Deliverable)
//  .HasForeignKey(s => s.ProjectPhaseId);

//builder.Entity<PaymentTerm>().HasOne(x => x.Deliverable)
// .WithMany(c => c.PaymentTerms)
// .HasForeignKey(s => s.DeliverableId);


//builder.Entity<ProjectPhase>()
//    .HasOne(x => x.Project).WithMany(pp => pp.ProjectPhases)
//    .HasForeignKey(s => s.ProjectId);
//builder.Entity<ProjectPhase>()
//    .HasOne(x => x.Phase).WithMany(z => z.ProjectPhases)
//    .HasForeignKey(s => s.PhaseId);
//builder.Entity<ProjectPhase>().HasKey(x => x.ProjectPhaseId);



//builder.Entity<InvoicePaymentTerm>().HasKey(x => new { x.PaymentTermId, x.InvoiceId });

//builder.Entity<InvoicePaymentTerm>().HasOne(x => x.Invoice)
//    .WithMany(pp => pp.InvoicePaymentTerms)
//    .HasForeignKey(s => s.PaymentTermId);

//builder.Entity<InvoicePaymentTerm>()
//    .HasOne(x => x.PaymentTerm).WithMany(z => z.InvoicePaymentTerms)
//    .HasForeignKey(s => s.PaymentTermId);

