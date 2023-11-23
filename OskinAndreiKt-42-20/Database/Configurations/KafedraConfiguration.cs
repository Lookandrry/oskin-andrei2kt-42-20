using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OskinAndreiKt_42_20.Models;
using OskinAndreiKt_42_20.Database.Helpers;

namespace OskinAndreiKt_42_20.Database.Configurations
{
    public class KafedraConfiguration : IEntityTypeConfiguration<Kafedra>
    {
        private const string TableName = "cd_kafedra";

        public void Configure(EntityTypeBuilder<Kafedra> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.KafedraId)
                .HasName($"pk_{TableName}_kafedra_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.KafedraId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.KafedraId)
                .HasColumnName("Идентификатор записи кафедры")
                .HasComment("Идентификатор записи кафедры");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.KafedraName)
                .IsRequired()
                .HasColumnName("Название кафедры")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.ToTable(TableName);
        }
    }
}
