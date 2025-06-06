using System.Data.Entity.ModelConfiguration;

namespace Task1.MVC.Models
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            // Указываем таблицу
            ToTable("Persons");

            // Указываем первичный ключ
            HasKey(p => p.Id);

            // Конфигурация полей
            Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}