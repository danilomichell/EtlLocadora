using System.Data;
using EtlLocadora.Data.Context;
using EtlLocadora.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EtlLocadora.Processamento
{
    public class ProcessoEtl : IProcessoEtl
    {
        private readonly LocadoraContext _context;

        public ProcessoEtl(LocadoraContext context)
        {
            _context = context;
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

            Truncate(TableName(_context.FtLocacoes));

            Truncate(TableName(_context.DmArtista));

            Truncate(TableName(_context.DmGravadora));

            Truncate(TableName(_context.DmSocio));

            Truncate(TableName(_context.DmTempo));

            Truncate(TableName(_context.DmTitulo));
        }

        private void Truncate(string tableName)
        {
            var cmd = $"delete from {tableName}";
            using var command = _context.Database.GetDbConnection().CreateCommand();
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
