using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FapProject.Models;

public partial class FapDbContext : DbContext
{
    public FapDbContext()
    {
    }

    public FapDbContext(DbContextOptions<FapDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administor> Administors { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassStudent> ClassStudents { get; set; }

    public virtual DbSet<Curriculum> Curricula { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradeCategory> GradeCategories { get; set; }

    public virtual DbSet<GradeItem> GradeItems { get; set; }

    public virtual DbSet<GradeReport> GradeReports { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(local); database=FapDB;user=sa;password=123;Integrated Security=true;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administor>(entity =>
        {
            entity.HasKey(e => e.AdministorId).HasName("PK__Administ__6D3B0645AF1DC5D0");

            entity.ToTable("Administor");

            entity.Property(e => e.AdministorId).HasColumnName("AdministorID");
            entity.Property(e => e.AdministorDob)
                .HasColumnType("datetime")
                .HasColumnName("AdministorDOB");
            entity.Property(e => e.AdministorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CA8635FBC");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");

            entity.HasOne(d => d.Slot).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SlotId)
                .HasConstraintName("FK__Attendanc__SlotI__47DBAE45");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Attendanc__Stude__49C3F6B7");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Attendanc__Teach__48CFD27E");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A07BBA9013");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Classroom).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.GoogleMeetLink).HasColumnType("text");
            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");

            entity.HasOne(d => d.Semester).WithMany(p => p.Classes)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Class__SemesterI__4E88ABD4");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Class__TeacherID__440B1D61");
        });

        modelBuilder.Entity<ClassStudent>(entity =>
        {
            entity.HasKey(e => e.ClassStudentId).HasName("PK__ClassStu__B8147839D94D3AC7");

            entity.ToTable("ClassStudent");

            entity.Property(e => e.ClassStudentId).HasColumnName("ClassStudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassStudents)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassStud__Class__44FF419A");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__ClassStud__Stude__45F365D3");
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.CurriculumId).HasName("PK__Curricul__06C9FA7C76A8CDB3");

            entity.ToTable("Curriculum");

            entity.Property(e => e.CurriculumId).HasColumnName("CurriculumID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectCode).HasMaxLength(7);

            entity.HasOne(d => d.Student).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Curriculu__Stude__4222D4EF");

            entity.HasOne(d => d.SubjectCodeNavigation).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.SubjectCode)
                .HasConstraintName("FK__Curriculu__Subje__4316F928");
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.HasKey(e => e.EducationLevelId).HasName("PK__Educatio__6F6237AD3559602F");

            entity.ToTable("EducationLevel");

            entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");
            entity.Property(e => e.EducationLevelTitle).HasMaxLength(20);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A372AF96487");

            entity.ToTable("Grade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeDate).HasColumnType("datetime");
            entity.Property(e => e.GradeItemId).HasColumnName("GradeItemID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectCode).HasMaxLength(7);
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");

            entity.HasOne(d => d.GradeItem).WithMany(p => p.Grades)
                .HasForeignKey(d => d.GradeItemId)
                .HasConstraintName("FK__Grade__GradeItem__4CA06362");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Grade__StudentID__4AB81AF0");

            entity.HasOne(d => d.SubjectCodeNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectCode)
                .HasConstraintName("FK__Grade__SubjectCo__4D94879B");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Grade__TeacherID__4BAC3F29");
        });

        modelBuilder.Entity<GradeCategory>(entity =>
        {
            entity.HasKey(e => e.GradeCategoryId).HasName("PK__GradeCat__C86CC40A57C6C2E3");

            entity.ToTable("GradeCategory");

            entity.Property(e => e.GradeCategoryId).HasColumnName("GradeCategoryID");
            entity.Property(e => e.GradeCategoryName).HasMaxLength(100);
            entity.Property(e => e.SubjectCode).HasMaxLength(7);
        });

        modelBuilder.Entity<GradeItem>(entity =>
        {
            entity.HasKey(e => e.GradeItemId).HasName("PK__GradeIte__A40A4056BA7505F3");

            entity.ToTable("GradeItem");

            entity.Property(e => e.GradeItemId).HasColumnName("GradeItemID");
            entity.Property(e => e.GradeCategoryId).HasColumnName("GradeCategoryID");
            entity.Property(e => e.GradeItemName).HasMaxLength(50);

            entity.HasOne(d => d.GradeCategory).WithMany(p => p.GradeItems)
                .HasForeignKey(d => d.GradeCategoryId)
                .HasConstraintName("FK__GradeItem__Grade__5070F446");
        });

        modelBuilder.Entity<GradeReport>(entity =>
        {
            entity.HasKey(e => e.GradeReportId).HasName("PK__GradeRep__DE03931202790522");

            entity.ToTable("GradeReport");

            entity.Property(e => e.GradeReportId).HasColumnName("GradeReportID");
            entity.Property(e => e.Comment).HasMaxLength(50);
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Grade).WithMany(p => p.GradeReports)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK__GradeRepo__Grade__4F7CD00D");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.MajorId).HasName("PK__Major__D5B8BFB1E5C9EAA7");

            entity.ToTable("Major");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.MajorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.SemesterId).HasName("PK__Semester__043301BD58EAC3B2");

            entity.ToTable("Semester");

            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.SemesterName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slot__0A124A4F5964CD1B");

            entity.ToTable("Slot");

            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");

            entity.HasOne(d => d.Class).WithMany(p => p.Slots)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Slot__ClassID__46E78A0C");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7939644805");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.StudentAddress).HasMaxLength(200);
            entity.Property(e => e.StudentCitizenId)
                .HasMaxLength(12)
                .HasColumnName("StudentCitizenID");
            entity.Property(e => e.StudentDob)
                .HasColumnType("datetime")
                .HasColumnName("StudentDOB");
            entity.Property(e => e.StudentEmail).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
            entity.Property(e => e.StudentPassword).HasMaxLength(32);
            entity.Property(e => e.StudentPhone).HasMaxLength(11);

            entity.HasOne(d => d.Major).WithMany(p => p.Students)
                .HasForeignKey(d => d.MajorId)
                .HasConstraintName("FK__Student__MajorID__412EB0B6");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectCode).HasName("PK__Subject__9F7CE1A835F6B1CB");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectCode).HasMaxLength(7);
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF2594432223FD9");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");
            entity.Property(e => e.DismissedDate).HasColumnType("datetime");
            entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.TeacherDob)
                .HasColumnType("datetime")
                .HasColumnName("TeacherDOB");
            entity.Property(e => e.TeacherEmail).HasMaxLength(50);
            entity.Property(e => e.TeacherName).HasMaxLength(50);
            entity.Property(e => e.TeacherPhone).HasMaxLength(11);

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.EducationLevelId)
                .HasConstraintName("FK__Teacher__Educati__5BE2A6F2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
