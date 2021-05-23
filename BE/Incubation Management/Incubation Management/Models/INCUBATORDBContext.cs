using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class INCUBATORDBContext : DbContext
    {
        public INCUBATORDBContext()
        {
        }

        public INCUBATORDBContext(DbContextOptions<INCUBATORDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CertificateTb> CertificateTbs { get; set; }
        public virtual DbSet<CertificationTypesTb> CertificationTypesTbs { get; set; }
        public virtual DbSet<CommitteReportsTb> CommitteReportsTbs { get; set; }
        public virtual DbSet<CommitteTb> CommitteTbs { get; set; }
        public virtual DbSet<CurrencyTb> CurrencyTbs { get; set; }
        public virtual DbSet<DeliverablesTb> DeliverablesTbs { get; set; }
        public virtual DbSet<EntrepreneurDeliverablesAttachmentsTb> EntrepreneurDeliverablesAttachmentsTbs { get; set; }
        public virtual DbSet<EntrepreneurDeliverablesTb> EntrepreneurDeliverablesTbs { get; set; }
        public virtual DbSet<ExperiencesTb> ExperiencesTbs { get; set; }
        public virtual DbSet<FieldsTb> FieldsTbs { get; set; }
        public virtual DbSet<FinanceRequirementsTb> FinanceRequirementsTbs { get; set; }
        public virtual DbSet<IdeaAttachmentsTb> IdeaAttachmentsTbs { get; set; }
        public virtual DbSet<IdeaMembersTb> IdeaMembersTbs { get; set; }
        public virtual DbSet<IdeaPhaseTb> IdeaPhaseTbs { get; set; }
        public virtual DbSet<MeetingReportsTb> MeetingReportsTbs { get; set; }
        public virtual DbSet<MembersTb> MembersTbs { get; set; }
        public virtual DbSet<NotificationTypeTb> NotificationTypeTbs { get; set; }
        public virtual DbSet<NotificationsTb> NotificationsTbs { get; set; }
        public virtual DbSet<ProjMembersTb> ProjMembersTbs { get; set; }
        public virtual DbSet<ProjectAttachmentsTb> ProjectAttachmentsTbs { get; set; }
        public virtual DbSet<ProjectDetailsTb> ProjectDetailsTbs { get; set; }
        public virtual DbSet<ProjectTb> ProjectTbs { get; set; }
        public virtual DbSet<ReceiptVoucherAttachmentsTb> ReceiptVoucherAttachmentsTbs { get; set; }
        public virtual DbSet<ReceivedRequirementAttachmentTb> ReceivedRequirementAttachmentTbs { get; set; }
        public virtual DbSet<RequirementDescriptionAttachmentTb> RequirementDescriptionAttachmentTbs { get; set; }
        public virtual DbSet<ResearchsTb> ResearchsTbs { get; set; }
        public virtual DbSet<SuperviserTb> SuperviserTbs { get; set; }
        public virtual DbSet<TheBusinessModelCanvasTb> TheBusinessModelCanvasTbs { get; set; }
        public virtual DbSet<UserTypesTb> UserTypesTbs { get; set; }
        public virtual DbSet<UsersTb> UsersTbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=INCUBATORDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CertificateTb>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.CertificateId });

                entity.ToTable("CERTIFICATE_TB");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.CertificateId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CERTIFICATE_ID");

                entity.Property(e => e.CertificateTypeId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CERTIFICATE_TYPE_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ORGANIZATION_NAME");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("TO_DATE");

                entity.HasOne(d => d.CertificateType)
                    .WithMany(p => p.CertificateTbs)
                    .HasForeignKey(d => d.CertificateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_TB_CERTIFICATION_TYPES_TB");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.CertificateTbs)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_TB_FIELDS_TB");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CertificateTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_TB_MEMBERS_TB");
            });

            modelBuilder.Entity<CertificationTypesTb>(entity =>
            {
                entity.HasKey(e => e.CertificationTypeId);

                entity.ToTable("CERTIFICATION_TYPES_TB");

                entity.Property(e => e.CertificationTypeId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CERTIFICATION_TYPE_ID");

                entity.Property(e => e.CertificationTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CERTIFICATION_TYPE_NAME");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");
            });

            modelBuilder.Entity<CommitteReportsTb>(entity =>
            {
                entity.HasKey(e => new { e.IdeaPhaseId, e.CommitteReportId });

                entity.ToTable("COMMITTE_REPORTS_TB");

                entity.HasIndex(e => e.IdeaPhaseId, "IX_COMMITTE_REPORTS_TB")
                    .IsUnique();

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.CommitteReportId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMMITTE_REPORT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Reason)
                    .HasMaxLength(1200)
                    .HasColumnName("REASON");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("date")
                    .HasColumnName("REPORT_DATE");

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(1200)
                    .HasColumnName("REPORT_DESCRIPTION");

                entity.Property(e => e.ReportTime).HasColumnName("REPORT_TIME");

                entity.Property(e => e.Result)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("RESULT");

                entity.HasOne(d => d.IdeaPhase)
                    .WithOne(p => p.CommitteReportsTb)
                    .HasForeignKey<CommitteReportsTb>(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMITTE_REPORTS_TB_IDEA_PHASE_TB");
            });

            modelBuilder.Entity<CommitteTb>(entity =>
            {
                entity.HasKey(e => new { e.IdeaPhaseId, e.CommitteId, e.MemberId });

                entity.ToTable("COMMITTE_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.CommitteId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("COMMITTE_ID");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.HasOne(d => d.IdeaPhase)
                    .WithMany(p => p.CommitteTbs)
                    .HasForeignKey(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMITTE_TB_IDEA_PHASE_TB");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommitteTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMITTE_TB_MEMBERS_TB");
            });

            modelBuilder.Entity<CurrencyTb>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("CURRENCY_TB");

                entity.Property(e => e.CurrencyId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CURRENCY_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CURRENCY_NAME");
            });

            modelBuilder.Entity<DeliverablesTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.DeliverableId });

                entity.ToTable("DELIVERABLES_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.DeliverableId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("DELIVERABLE_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.IsActive)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.DeliverablesTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DELIVERABLES_TB_PROJECT_TB");
            });

            modelBuilder.Entity<EntrepreneurDeliverablesAttachmentsTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.DeliverableId, e.AttachmentId });

                entity.ToTable("ENTREPRENEUR_DELIVERABLES_ATTACHMENTS_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.DeliverableId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("DELIVERABLE_ID");

                entity.Property(e => e.AttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("ATTACHMENT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.HasOne(d => d.Deliverable)
                    .WithMany(p => p.EntrepreneurDeliverablesAttachmentsTbs)
                    .HasPrincipalKey(p => p.DeliverableId)
                    .HasForeignKey(d => d.DeliverableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTREPRENEUR_DELIVERABLES_ATTACHMENTS_TB_ENTREPRENEUR_DELIVERABLES_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EntrepreneurDeliverablesAttachmentsTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTREPRENEUR_DELIVERABLES_ATTACHMENTS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<EntrepreneurDeliverablesTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.DeliverableId });

                entity.ToTable("ENTREPRENEUR_DELIVERABLES_TB");

                entity.HasIndex(e => e.DeliverableId, "IX_ENTREPRENEUR_DELIVERABLES_TB")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.DeliverableId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("DELIVERABLE_ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1200)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.EntrepreneurComments)
                    .HasMaxLength(1200)
                    .HasColumnName("ENTREPRENEUR_COMMENTS");

                entity.Property(e => e.IsActive)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EntrepreneurDeliverablesTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTREPRENEUR_DELIVERABLES_TB_PROJECT_TB");
            });

            modelBuilder.Entity<ExperiencesTb>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ExperienceId });

                entity.ToTable("EXPERIENCES_TB");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.ExperienceId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXPERIENCE_ID");

                entity.Property(e => e.CompenyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COMPENY_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("TO_DATE");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.ExperiencesTbs)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIENCES_TB_FIELDS_TB");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ExperiencesTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIENCES_TB_MEMBERS_TB");
            });

            modelBuilder.Entity<FieldsTb>(entity =>
            {
                entity.HasKey(e => e.FieldId);

                entity.ToTable("FIELDS_TB");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FIELD_NAME");
            });

            modelBuilder.Entity<FinanceRequirementsTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.FinanceRequirementsId });

                entity.ToTable("FINANCE_REQUIREMENTS_TB");

                entity.HasIndex(e => e.FinanceRequirementsId, "IX_FINANCE_REQUIREMENTS_TB")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.FinanceRequirementsId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FINANCE_REQUIREMENTS_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.CurrencyId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CURRENCY_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.RequestTime).HasColumnName("REQUEST_TIME");

                entity.Property(e => e.RequirementType)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("REQUIREMENT_TYPE");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.FinanceRequirementsTbs)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FINANCE_REQUIREMENTS_TB_CURRENCY_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.FinanceRequirementsTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FINANCE_REQUIREMENTS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<IdeaAttachmentsTb>(entity =>
            {
                entity.HasKey(e => new { e.IdeaPhaseId, e.AttachmentId });

                entity.ToTable("IDEA_ATTACHMENTS_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.AttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTACHMENT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Descriptoin)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTOIN");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.HasOne(d => d.IdeaPhase)
                    .WithMany(p => p.IdeaAttachmentsTbs)
                    .HasForeignKey(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDEA_ATTACHMENTS_TB_IDEA_PHASE_TB");
            });

            modelBuilder.Entity<IdeaMembersTb>(entity =>
            {
                entity.HasKey(e => new { e.IdeaPhaseId, e.IdeaMemberId, e.UserId });

                entity.ToTable("IDEA_MEMBERS_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.IdeaMemberId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDEA_MEMBER_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.IsActive)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .HasColumnName("TEL");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("TO_DATE");

                entity.HasOne(d => d.IdeaPhase)
                    .WithMany(p => p.IdeaMembersTbs)
                    .HasForeignKey(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDEA_MEMBERS_TB_IDEA_PHASE_TB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IdeaMembersTbs)
                    .HasPrincipalKey(p => p.MemberId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDEA_MEMBERS_TB_USERS_TB");
            });

            modelBuilder.Entity<IdeaPhaseTb>(entity =>
            {
                entity.HasKey(e => e.IdeaPhaseId);

                entity.ToTable("IDEA_PHASE_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.AnticipatedDate)
                    .HasColumnType("date")
                    .HasColumnName("ANTICIPATED_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PROJECT_NAME");

                entity.Property(e => e.ProjectPhase)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("PROJECT_PHASE");

                entity.Property(e => e.Reason)
                    .HasMaxLength(1200)
                    .HasColumnName("REASON");

                entity.Property(e => e.Result)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("RESULT");

                entity.Property(e => e.TheBusinessModelCanvasId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("THE_BUSINESS_MODEL_CANVAS_ID");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.IdeaPhaseTbs)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDEA_PHASE_TB_FIELDS_TB");
            });

            modelBuilder.Entity<MeetingReportsTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.MeetingReportId });

                entity.ToTable("MEETING_REPORTS_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.MeetingReportId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEETING_REPORT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.MeetingSummary)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("MEETING_SUMMARY");

                entity.Property(e => e.MeetingTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MEETING_TITLE");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("date")
                    .HasColumnName("REPORT_DATE");

                entity.Property(e => e.ReportTime).HasColumnName("REPORT_TIME");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.MeetingReportsTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEETING_REPORTS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<MembersTb>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("MEMBERS_TB");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ContactPersonName)
                    .HasMaxLength(100)
                    .HasColumnName("CONTACT_PERSON_NAME");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IsActivae)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_ACTIVAE");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MEMBER_NAME");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("TEL");
            });

            modelBuilder.Entity<NotificationTypeTb>(entity =>
            {
                entity.HasKey(e => e.NotificationTypeId);

                entity.ToTable("NOTIFICATION_TYPE_TB");

                entity.Property(e => e.NotificationTypeId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIFICATION_TYPE_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.NotificationTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NOTIFICATION_TYPE_NAME");
            });

            modelBuilder.Entity<NotificationsTb>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.ReceiverId, e.CreatedBy });

                entity.ToTable("NOTIFICATIONS_TB");

                entity.Property(e => e.NotificationId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIFICATION_ID");

                entity.Property(e => e.ReceiverId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("RECEIVER_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TypeId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("TYPE_ID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NotificationsTbCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATIONS_TB_MEMBERS_TB1");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.NotificationsTbReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATIONS_TB_MEMBERS_TB");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.NotificationsTbs)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTIFICATIONS_TB_NOTIFICATION_TYPE_TB");
            });

            modelBuilder.Entity<ProjMembersTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.MemberId });

                entity.ToTable("PROJ_MEMBERS_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.IsActive)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(100)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("TO_DATE");

                entity.Property(e => e.UserTypeId)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("USER_TYPE_ID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ProjMembersTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJ_MEMBERS_TB_MEMBERS_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjMembersTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJ_MEMBERS_TB_PROJECT_TB");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.ProjMembersTbs)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJ_MEMBERS_TB_USER_TYPES_TB");
            });

            modelBuilder.Entity<ProjectAttachmentsTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.ProjectAttachmentId })
                    .HasName("PK_PROJECT_ATTACHMENTS");

                entity.ToTable("PROJECT_ATTACHMENTS_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.ProjectAttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROJECT_ATTACHMENT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectAttachmentsTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_ATTACHMENTS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<ProjectDetailsTb>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("PROJECT_DETAILS_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(1200)
                    .HasColumnName("COMPANY_DESCRIPTION");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.ExcutiveSummery)
                    .HasMaxLength(1200)
                    .HasColumnName("EXCUTIVE_SUMMERY");

                entity.Property(e => e.FinancialsProjections)
                    .HasMaxLength(1200)
                    .HasColumnName("FINANCIALS_PROJECTIONS");

                entity.Property(e => e.FundingRequirements)
                    .HasMaxLength(1200)
                    .HasColumnName("FUNDING_REQUIREMENTS");

                entity.Property(e => e.ManagementTeam)
                    .HasMaxLength(1200)
                    .HasColumnName("MANAGEMENT_TEAM");

                entity.Property(e => e.MarketAnalysis)
                    .HasMaxLength(1200)
                    .HasColumnName("MARKET_ANALYSIS");

                entity.Property(e => e.MarketingPlan)
                    .HasMaxLength(1200)
                    .HasColumnName("MARKETING_PLAN");

                entity.Property(e => e.ReviewSchedule)
                    .HasMaxLength(1200)
                    .HasColumnName("REVIEW_SCHEDULE");

                entity.Property(e => e.ServiceOrProduct)
                    .HasMaxLength(1200)
                    .HasColumnName("SERVICE_OR_PRODUCT");

                entity.HasOne(d => d.Project)
                    .WithOne(p => p.ProjectDetailsTb)
                    .HasForeignKey<ProjectDetailsTb>(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_DETAILS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<ProjectTb>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("PROJECT_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.ActualDate)
                    .HasColumnType("date")
                    .HasColumnName("ACTUAL_DATE");

                entity.Property(e => e.AnticipatedDate)
                    .HasColumnType("date")
                    .HasColumnName("ANTICIPATED_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.ProjectDescription)
                    .IsRequired()
                    .HasMaxLength(1200)
                    .HasColumnName("PROJECT_DESCRIPTION");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PROJECT_NAME");

                entity.Property(e => e.ProjectStatus)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("PROJECT_STATUS");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.ProjectTbs)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_TB_FIELDS_TB");

                entity.HasOne(d => d.IdeaPhase)
                    .WithMany(p => p.ProjectTbs)
                    .HasForeignKey(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_TB_IDEA_PHASE_TB");
            });

            modelBuilder.Entity<ReceiptVoucherAttachmentsTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.FinanceRequirementsId, e.ReceiptVoucherAttachmentId });

                entity.ToTable("RECEIPT_VOUCHER_ATTACHMENTS_TB");

                entity.HasIndex(e => e.ReceiptVoucherAttachmentId, "IX_RECEIPT_VOUCHER_ATTACHMENTS_TB")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.FinanceRequirementsId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FINANCE_REQUIREMENTS_ID");

                entity.Property(e => e.ReceiptVoucherAttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("RECEIPT_VOUCHER_ATTACHMENT_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.FinanceRequirements)
                    .WithMany(p => p.ReceiptVoucherAttachmentsTbs)
                    .HasPrincipalKey(p => p.FinanceRequirementsId)
                    .HasForeignKey(d => d.FinanceRequirementsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIPT_VOUCHER_ATTACHMENTS_TB_FINANCE_REQUIREMENTS_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ReceiptVoucherAttachmentsTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIPT_VOUCHER_ATTACHMENTS_TB_PROJECT_TB");
            });

            modelBuilder.Entity<ReceivedRequirementAttachmentTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.FinanceRequirementsId, e.ReceiptVoucherAttachmentId, e.ReceivedRequirementAttachment });

                entity.ToTable("RECEIVED_REQUIREMENT_ATTACHMENT_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.FinanceRequirementsId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FINANCE_REQUIREMENTS_ID");

                entity.Property(e => e.ReceiptVoucherAttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("RECEIPT_VOUCHER_ATTACHMENT_ID");

                entity.Property(e => e.ReceivedRequirementAttachment)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("RECEIVED_REQUIREMENT_ATTACHMENT");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.FinanceRequirements)
                    .WithMany(p => p.ReceivedRequirementAttachmentTbs)
                    .HasPrincipalKey(p => p.FinanceRequirementsId)
                    .HasForeignKey(d => d.FinanceRequirementsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIVED_REQUIREMENT_ATTACHMENT_TB_FINANCE_REQUIREMENTS_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ReceivedRequirementAttachmentTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIVED_REQUIREMENT_ATTACHMENT_TB_PROJECT_TB");

                entity.HasOne(d => d.ReceiptVoucherAttachment)
                    .WithMany(p => p.ReceivedRequirementAttachmentTbs)
                    .HasPrincipalKey(p => p.ReceiptVoucherAttachmentId)
                    .HasForeignKey(d => d.ReceiptVoucherAttachmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIVED_REQUIREMENT_ATTACHMENT_TB_RECEIPT_VOUCHER_ATTACHMENTS_TB");
            });

            modelBuilder.Entity<RequirementDescriptionAttachmentTb>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.FinanceRequirementsId, e.HardwareDescriptionAttachmentId });

                entity.ToTable("REQUIREMENT_DESCRIPTION_ATTACHMENT_TB");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.FinanceRequirementsId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FINANCE_REQUIREMENTS_ID");

                entity.Property(e => e.HardwareDescriptionAttachmentId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("HARDWARE_DESCRIPTION_ATTACHMENT_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.FinanceRequirements)
                    .WithMany(p => p.RequirementDescriptionAttachmentTbs)
                    .HasPrincipalKey(p => p.FinanceRequirementsId)
                    .HasForeignKey(d => d.FinanceRequirementsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUIREMENT_DESCRIPTION_ATTACHMENT_TB_FINANCE_REQUIREMENTS_TB");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.RequirementDescriptionAttachmentTbs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUIREMENT_DESCRIPTION_ATTACHMENT_TB_PROJECT_TB");
            });

            modelBuilder.Entity<ResearchsTb>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ResearchId });

                entity.ToTable("RESEARCHS_TB");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.ResearchId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RESEARCH_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FieldId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FIELD_ID");

                entity.Property(e => e.ResearchName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RESEARCH_NAME");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.ResearchsTbs)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESEARCHS_TB_FIELDS_TB");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ResearchsTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESEARCHS_TB_MEMBERS_TB");
            });

            modelBuilder.Entity<SuperviserTb>(entity =>
            {
                entity.HasKey(e => new { e.IdeaPhaseId, e.SuperviserId, e.MemberId });

                entity.ToTable("SUPERVISER_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.SuperviserId)
                    .HasColumnType("numeric(9, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SUPERVISER_ID");

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.HasOne(d => d.IdeaPhase)
                    .WithMany(p => p.SuperviserTbs)
                    .HasForeignKey(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPERVISER_TB_IDEA_PHASE_TB");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.SuperviserTbs)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPERVISER_TB_MEMBERS_TB");
            });

            modelBuilder.Entity<TheBusinessModelCanvasTb>(entity =>
            {
                entity.HasKey(e => e.IdeaPhaseId)
                    .HasName("PK_THE_BUSINESS_MODEL_CANVAS");

                entity.ToTable("THE_BUSINESS_MODEL_CANVAS_TB");

                entity.Property(e => e.IdeaPhaseId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("IDEA_PHASE_ID");

                entity.Property(e => e.Channels)
                    .HasMaxLength(1200)
                    .HasColumnName("CHANNELS");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(1200)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CostStructure)
                    .HasMaxLength(1200)
                    .HasColumnName("COST_STRUCTURE");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.CustomerRelationships)
                    .HasMaxLength(1200)
                    .HasColumnName("CUSTOMER_RELATIONSHIPS");

                entity.Property(e => e.CustomerSegments)
                    .HasMaxLength(1200)
                    .HasColumnName("CUSTOMER_SEGMENTS");

                entity.Property(e => e.KeyActivities)
                    .HasMaxLength(1200)
                    .HasColumnName("KEY_ACTIVITIES");

                entity.Property(e => e.KeyPartners)
                    .HasMaxLength(1200)
                    .HasColumnName("KEY_PARTNERS");

                entity.Property(e => e.KeyResources)
                    .HasMaxLength(1200)
                    .HasColumnName("KEY_RESOURCES");

                entity.Property(e => e.RevenueStreams)
                    .HasMaxLength(1200)
                    .HasColumnName("REVENUE_STREAMS");

                entity.Property(e => e.ValueProposition)
                    .HasMaxLength(1200)
                    .HasColumnName("VALUE_PROPOSITION");

                entity.HasOne(d => d.IdeaPhase)
                    .WithOne(p => p.TheBusinessModelCanvasTb)
                    .HasForeignKey<TheBusinessModelCanvasTb>(d => d.IdeaPhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THE_BUSINESS_MODEL_CANVAS_TB_IDEA_PHASE_TB");
            });

            modelBuilder.Entity<UserTypesTb>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("USER_TYPES_TB");

                entity.Property(e => e.UserTypeId)
                    .HasColumnType("numeric(2, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_TYPE_ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("USER_TYPE_NAME");
            });

            modelBuilder.Entity<UsersTb>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.UserName });

                entity.ToTable("USERS_TB");

                entity.HasIndex(e => e.MemberId, "IX_USERS_TB")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "IX_USERS_TB_1")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("MEMBER_ID");

                entity.Property(e => e.UserName)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_ON");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserTypeId)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("USER_TYPE_ID");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.UsersTb)
                    .HasForeignKey<UsersTb>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_TB_MEMBERS_TB");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UsersTbs)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_TB_USER_TYPES_TB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
