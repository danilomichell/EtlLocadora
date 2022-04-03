using System.Data;
using EtlLocadora.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EtlLocadora.Processamento
{
    public class ProcessoEtl : IProcessoEtl
    {
        public readonly LocadoraContext Context;

        public ProcessoEtl(LocadoraContext context)
        {
            Context = context;
        }
        public void Processar(int opt)
        {
            switch (opt)
            {
                case 1:
                    Exclude();
                    break;
                case 2:
                    ProcessarEtl();
                    break;
            }
        }

        private void ProcessarEtl()
        {

        }

        private void Exclude()
        {

            Truncate(TableName(Context.FtLocacoes));

            Truncate(TableName(Context.DmArtista));

            Truncate(TableName(Context.DmGravadora));

            Truncate(TableName(Context.DmSocio));

            Truncate(TableName(Context.DmTempo));

            Truncate(TableName(Context.DmTitulo));
        }

        private void Truncate(string tableName)
        {
            var cmd = $"delete from {tableName}";
            using var command = Context.Database.GetDbConnection().CreateCommand();
            if (command.Connection!.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }

        private static string GetName(IReadOnlyAnnotatable entityType, string defaultSchemaName = "dwlocadora")
        {
            var schema = entityType.FindAnnotation("Relational:Schema")!.Value;
            var tableName = entityType.GetAnnotation("Relational:TableName").Value!.ToString();
            var schemaName = schema == null ? defaultSchemaName : schema.ToString();
            var name = $"{schemaName}.{tableName}";
            return name;
        }

        private static string TableName<T>(DbSet<T> dbSet) where T : class
        {
            var entityType = dbSet.EntityType;
            return GetName(entityType);
        }
    }
    public interface IProcessoEtl
    {
        void Processar(int opt);
    }
}
