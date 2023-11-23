using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OskinAndreiKt_42_20.Models;
using OskinAndreiKt_42_20.Database.Helpers;

namespace OskinAndreiKt_42_20.Database.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        private const string TableName = "cd_degree";

        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.DegreeId)
                .HasName($"pk_{TableName}_degree_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.DegreeId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.DegreeId)
                .HasColumnName("degree_id")
                .HasComment("Идентификатор записи ученой степени");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.Name_degree)
                .IsRequired()
            .HasColumnName("c_name_degree")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название ученой степени");


        }
    }
}
