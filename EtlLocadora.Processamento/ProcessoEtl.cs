﻿using System.Data;
using EtlLocadora.Data.Context;
using EtlLocadora.Processamento.Etl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EtlLocadora.Processamento
{
    public class ProcessoEtl : IProcessoEtl
    {
        private readonly LocadoraContext _context;
        private readonly LocadoraDwContext _dwContext;

        public ProcessoEtl(LocadoraContext context, LocadoraDwContext dwContext)
        {
            _context = context;
            _dwContext = dwContext;
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
            var extracao = new Extract(_context);
        }


        private void Exclude()
        {

            //Truncate(TableName(_context.FtLocacoes));

            //Truncate(TableName(_context.DmArtista));

            //Truncate(TableName(_context.DmGravadora));

            //Truncate(TableName(_context.DmSocio));

            //Truncate(TableName(_context.DmTempo));

            //Truncate(TableName(_context.DmTitulo));
        }

        private void Truncate(string tableName)
        {
            var cmd = $"delete from {tableName}";
            using var command = _dwContext.Database.GetDbConnection().CreateCommand();
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
