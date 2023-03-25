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
        => optionsBuilder.UseSqlServer("server=AKAISAIZA;database=FapDB;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Administor");

            entity.Property(e => e.AdministorDob)
                .HasColumnType("datetime")
                .HasColumnName("AdministorDOB");
            entity.Property(e => e.AdministorId).HasColumnName("AdministorID");
            entity.Property(e => e.AdministorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Class");

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
        });

        modelBuilder.Entity<ClassStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ClassStudent");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassStudentId).HasColumnName("ClassStudentID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Curriculum");

            entity.Property(e => e.CurriculumId).HasColumnName("CurriculumID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectCode).HasMaxLength(7);
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EducationLevel");

            entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");
            entity.Property(e => e.EducationLevelTitle).HasMaxLength(20);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Grade");

            entity.Property(e => e.GradeDate).HasColumnType("datetime");
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeItemId).HasColumnName("GradeItemID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.SubjectCode).HasMaxLength(7);
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");
        });

        modelBuilder.Entity<GradeCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GradeCategory");

            entity.Property(e => e.GradeCategoryId).HasColumnName("GradeCategoryID");
            entity.Property(e => e.GradeCategoryName).HasMaxLength(100);
            entity.Property(e => e.SubjectCode).HasMaxLength(7);
        });

        modelBuilder.Entity<GradeItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GradeItem");

            entity.Property(e => e.GradeCategoryId).HasColumnName("GradeCategoryID");
            entity.Property(e => e.GradeItemId).HasColumnName("GradeItemID");
            entity.Property(e => e.GradeItemName).HasMaxLength(50);
        });

        modelBuilder.Entity<GradeReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GradeReport");

            entity.Property(e => e.Comment).HasMaxLength(50);
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeReportId).HasColumnName("GradeReportID");
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Major");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.MajorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Semester");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");
            entity.Property(e => e.SemesterName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Slot");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.StudentAddress).HasMaxLength(200);
            entity.Property(e => e.StudentCitizenId)
                .HasMaxLength(12)
                .HasColumnName("StudentCitizenID");
            entity.Property(e => e.StudentDob)
                .HasColumnType("datetime")
                .HasColumnName("StudentDOB");
            entity.Property(e => e.StudentEmail).HasMaxLength(50);
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("StudentID");
            entity.Property(e => e.StudentName).HasMaxLength(50);
            entity.Property(e => e.StudentPassword).HasMaxLength(32);
            entity.Property(e => e.StudentPhone).HasMaxLength(11);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Subject");

            entity.Property(e => e.SubjectCode).HasMaxLength(7);
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Teacher");

            entity.Property(e => e.DismissedDate).HasColumnType("datetime");
            entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.TeacherDob)
                .HasColumnType("datetime")
                .HasColumnName("TeacherDOB");
            entity.Property(e => e.TeacherEmail).HasMaxLength(50);
            entity.Property(e => e.TeacherId)
                .HasMaxLength(10)
                .HasColumnName("TeacherID");
            entity.Property(e => e.TeacherName).HasMaxLength(50);
            entity.Property(e => e.TeacherPhone).HasMaxLength(11);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
